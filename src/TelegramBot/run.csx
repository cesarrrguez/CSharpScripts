#load "../../packages.csx"

#load "services.csx"
#load "configurations.csx"

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
