#load "entities.csx"
#load "configurations.csx"
#load "data.csx"
#load "utils.csx"

#r "nuget: Dapper, 2.0.90"
#r "nuget: Microsoft.Data.Sqlite, 5.0.7"
#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"

using Microsoft.Extensions.DependencyInjection;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        var userService = _serviceProvider.GetService<IUserService>();

        // Add User
        var user = new User { Name = "César" };
        await userService.AddAsync(user);

        // Get User
        WriteLine(await userService.GetByIdAsync(user.Id));

        // Update User
        user.Name = "James";
        await userService.UpdateAsync(user);

        // Get All Users
        var users = await userService.GetAllAsync();
        users.ToList().ForEach(user => WriteLine(user));

        // Delete
        await userService.DeleteAsync(user.Id);

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
