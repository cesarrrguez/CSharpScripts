#load "services.csx"
#load "controllers.csx"

#r "nuget: Microsoft.Extensions.Logging, 7.0.0"
#r "nuget: Microsoft.Extensions.Logging.Console, 7.0.0"
#r "nuget: Microsoft.Extensions.DependencyInjection, 7.0.0"

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        var userController = _serviceProvider.GetRequiredService<IUserController>();
        WriteLine(await userController.GetAsync());

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        // Logging
        services.AddLogging(options => options.AddConsole());

        // IoC
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserController, UserController>();

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
