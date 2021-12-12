#load "entities.csx"
#load "configurations.csx"
#load "data.csx"
#load "utils.csx"

#r "nuget: Dapper, 2.0.90"
#r "nuget: Microsoft.Data.Sqlite, 5.0.7"
#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"

using Microsoft.Extensions.DependencyInjection;

App.Run();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        var userService = _serviceProvider.GetService<IUserService>();

        // Add User
        var user = new User { Name = "César" };
        userService.AddAsync(user);

        // Get User
        WriteLine(userService.GetByIdAsync(user.Id).Result);

        // Update User
        user.Name = "James";
        userService.UpdateAsync(user);

        // Get All Users
        userService.GetAllAsync().Result.ToList().ForEach(user => WriteLine(user));

        // Delete
        userService.DeleteAsync(user.Id);

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
