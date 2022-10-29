using System.Reflection;

namespace Refiz.Razor.Infrastructure.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder ConfigureCustomConfiguration(this IConfigurationBuilder confBuilder, Assembly? userSecretOfAssembly = null)
    {
        confBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true, reloadOnChange: true)
            .AddJsonFile("appsettings.local.json", true, reloadOnChange: true)
            .AddEnvironmentVariables();

        if (userSecretOfAssembly != null)
        {
            confBuilder.AddUserSecrets(userSecretOfAssembly);
        }

        return confBuilder;
    }
}