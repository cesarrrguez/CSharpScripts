#load "configurations.csx"
#load "controllers.csx"

#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"

using Microsoft.Extensions.DependencyInjection;

// Call App entry point
App.Run();

public class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        // Get user controller
        var userController = _serviceProvider.GetService<IUserController>();

        // Print output
        Console.WriteLine(userController.Get());

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

        if (_serviceProvider is IDisposable)
        {
            ((IDisposable)_serviceProvider).Dispose();
        }
    }
}
