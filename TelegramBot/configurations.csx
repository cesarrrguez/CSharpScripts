#load "interfaces.csx"
#load "crossCutting.csx"
#load "settings.csx"
#load "utils.csx"

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

        var configuration = new ConfigurationBuilder()
                        .SetBasePath(FolderUtil.GetCurrentDirectoryName())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

        services.Configure<TelegramBotSettings>(configuration.GetSection(nameof(TelegramBotSettings)));
    }
}
