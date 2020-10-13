#load "interfaces.csx"
#load "crossCutting.csx"
#load "settings.csx"

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        IoC.RegisterServices(services);
    }
}

public static class SettingsConfig
{
    public static void AddSettingsConfiguration(IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var path = Path.Combine(Directory.GetCurrentDirectory(), "DB/MongoDB");
        var configuration = new ConfigurationBuilder()
                        .SetBasePath(path)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

        services.Configure<DbSettings>(configuration.GetSection(nameof(DbSettings)));
    }
}
