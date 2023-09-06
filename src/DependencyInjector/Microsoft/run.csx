#load "configurations.csx"
#load "controllers.csx"

#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"

using Microsoft.Extensions.DependencyInjection;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        var userController = _serviceProvider.GetService<IUserController>();
        await userController.GetAsync();

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

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
