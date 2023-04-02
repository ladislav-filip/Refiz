using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refiz.Infrastructure;
using Refiz.Queries.Infrastructure.Extensions;

namespace Refiz.Application.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    private const string CipherSaltKey = "CIPHER_SALT";
    public static IServiceCollection AddCustomApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration, string connStringKey)
    {
        var connectionString = configuration.GetConnectionString(connStringKey);
        // serviceCollection.AddDbContext<RefizContext>(opt => opt.UseSqlServer(connectionString));

        var serverVesrion = new MariaDbServerVersion(new Version(10, 9, 5));
        
        serviceCollection.AddDbContext<RefizContext>(opt => 
            opt.UseMySql(connectionString, serverVesrion)
                .EnableDetailedErrors()
            );
        
        serviceCollection.AddScoped<IRefizContext, RefizContext>();
        serviceCollection.AddTransient<ICipher>(_ => new Cipher(configuration.GetValue<string>(CipherSaltKey)));
        serviceCollection.AddMediatR(typeof(Cipher));

        serviceCollection.AddCustomQueriesServices(configuration);

        var asm = Assembly.GetExecutingAssembly();
        serviceCollection.AddAutoMapper(asm);

        return serviceCollection;
    }
}