using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Refiz.Queries.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomQueriesServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Scan(scan =>
            scan.FromAssemblyOf<IBaseQuery>()
                .AddClasses()
                .AsMatchingInterface()
                .WithTransientLifetime()
        );

        var asm = Assembly.GetExecutingAssembly();
        serviceCollection.AddAutoMapper(asm);

        return serviceCollection;
    }
}