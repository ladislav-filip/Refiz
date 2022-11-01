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
    public static IServiceCollection AddCustomApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Refiz");
        serviceCollection.AddDbContext<RefizContext>(opt => opt.UseSqlServer(connectionString));
        serviceCollection.AddScoped<IRefizContext, RefizContext>();
        serviceCollection.AddTransient<ICipher>(_ => new Cipher(configuration.GetValue<string>(CipherSaltKey)));
        serviceCollection.AddMediatR(typeof(Cipher));

        serviceCollection.AddCustomQueriesServices(configuration);

        var asm = Assembly.GetExecutingAssembly();
        serviceCollection.AddAutoMapper(asm);

        return serviceCollection;
    }
}