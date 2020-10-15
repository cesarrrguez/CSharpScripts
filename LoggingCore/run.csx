#load "services.csx"
#load "controllers.csx"

#r "nuget: Microsoft.Extensions.Logging, 3.1.0"
#r "nuget: Microsoft.Extensions.Logging.Console, 3.1.0"
#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Call App entry point
App.Run();

public class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        var logger = _serviceProvider.GetRequiredService<ILogger<App>>();
        logger.LogInformation("The application has started");

        var userController = _serviceProvider.GetRequiredService<IUserController>();
        Console.WriteLine(userController.Get());

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
