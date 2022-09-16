#load "services.csx"
#load "configurations.csx"

#r "nuget: Telegram.Bot, 15.7.1"
#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Json, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Binder, 3.1.0"
#r "nuget: Microsoft.Extensions.Options, 3.1.0"
#r "nuget: Microsoft.Extensions.Options.ConfigurationExtensions, 3.1.0"

using Microsoft.Extensions.DependencyInjection;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        var telegramBotService = _serviceProvider.GetService<ITelegramBotService>();
        await telegramBotService.SayHelloAsync();

        do
        {
            Write("Enter '0' to exit: ");
        } while (ReadLine() != "0");

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        SettingsConfig.AddSettingsConfiguration(services);
        DependencyInjectionConfig.AddDependencyInjectionConfiguration(services);

        _serviceProvider = services.BuildServiceProvider();
    }

    private static void DisposeServices()
    {
        if (_serviceProvider == null) return;

        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
