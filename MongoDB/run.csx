#load "configurations.csx"
#load "controllers.csx"
#load "entities.csx"

#r "nuget: MongoDB.Driver, 2.11.2"
#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Json, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Binder, 3.1.0"
#r "nuget: Microsoft.Extensions.Options, 3.1.0"
#r "nuget: Microsoft.Extensions.Options.ConfigurationExtensions, 3.1.0"

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Call App entry point
App.Run();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        // Get user controller
        var userController = _serviceProvider.GetService<IUserController>();

        // Create
        var user1 = new User() { Name = "James", Age = 21 };
        userController.Create(user1);

        // Get
        userController.Get(user1.Id);

        // Create
        var user2 = new User() { Name = "Olivia", Age = 36 };
        userController.Create(user2);

        // Get
        userController.Get();

        // Delete
        userController.Delete(user1.Id);
        userController.Delete(user2.Id);

        // Get
        userController.Get();

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
