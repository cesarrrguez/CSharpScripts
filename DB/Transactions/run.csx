#load "entities.csx"
#load "configurations.csx"
#load "data.csx"
#load "controllers.csx"
#load "utils.csx"

#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// Call App entry point
App.Run();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        // Ensure the database is created
        _serviceProvider.GetService<DataContext>().Database.EnsureCreated();

        var order = new Order("Laptop", 3);
        var customer = new Customer("James", "Brown");
        var request = new OrderRequest(order, customer);

        var response = _serviceProvider.GetService<IOrderController>().Add(request);
        WriteLine(response.Success);

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddDbContext<DataContext>(options => options.UseSqlite($"Filename={FolderUtil.GetCurrentDirectoryName()}/database.db"));

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
