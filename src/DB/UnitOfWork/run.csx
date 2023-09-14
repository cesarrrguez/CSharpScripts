#load "../../../packages.csx"

#load "entities.csx"
#load "configurations.csx"
#load "data.csx"
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

        // Get data context
        var dataContext = _serviceProvider.GetService<DataContext>();
        dataContext.Database.EnsureCreated();

        // Create Unit of Work
        using var unitOfWork = new UnitOfWork(dataContext);
        var order = new Order("Laptop", 3);
        await unitOfWork.OrderRepository.AddAsync(order);

        var customer = new Customer("James", "Brown");
        await unitOfWork.CustomerRepository.AddAsync(customer);

        unitOfWork.Commit();

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
