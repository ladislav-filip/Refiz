#region Info
// FileName:    ConfigurationBuilderExtensions.cs
// Author:      Ladislav Filip
// Created:     14.05.2022
#endregion

using System.Reflection;

namespace Refiz.Blazor.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder ConfigureCustomConfiguration(this IConfigurationBuilder confBuilder, Assembly? userSecretOfAssembly = null)
    {
        confBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
            .AddJsonFile("appsettings.local.json", true)
            .AddEnvironmentVariables();

        if (userSecretOfAssembly != null)
        {
            confBuilder.AddUserSecrets(userSecretOfAssembly);
        }

        return confBuilder;
    }
}