#load "../../../packages.csx"

#load "entities.csx"
#load "configurations.csx"
#load "data.csx"
#load "controllers.csx"
#load "utils.csx"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        // Ensure the database is created
        _serviceProvider.GetService<DataContext>().Database.EnsureCreated();

        var order = new Order("Laptop", 3);
        var customer = new Customer("James", "Brown");
        var request = new OrderRequest(order, customer);

        var response = await _serviceProvider.GetService<IOrderController>().AddAsync(request);
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
