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

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        // Get user controller
        var userController = _serviceProvider.GetService<IUserController>();

        // Create
        var user1 = new User() { Name = "James", Age = 21 };
        await userController.CreateAsync(user1);

        // Get
        await userController.GetAsync(user1.Id);

        // Update
        user1.Age = 12;
        await userController.UpdateAsync(user1.Id, user1);

        // Create
        var user2 = new User() { Name = "Olivia", Age = 36 };
        await userController.CreateAsync(user2);

        // Get
        await userController.GetAllAsync();

        // Delete
        await userController.DeleteAsync(user1.Id);
        await userController.DeleteAsync(user2.Id);

        // Get
        await userController.GetAllAsync();

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
