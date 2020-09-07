#load "entities.csx"
#load "configurations.csx"
#load "data.csx"

#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// Call App entry point
App.Run();

public class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        // Get data context
        var dataContext = _serviceProvider.GetService<DataContext>();
        dataContext.Database.EnsureCreated();

        // Create Unit of Work 
        using (var unitOfWork = new UnitOfWork(dataContext))
        {
            var order = new Order("Laptop", 3);
            unitOfWork.OrderRepository.Add(order);

            var customer = new Customer("James", "Brown");
            unitOfWork.CustomerRepository.Add(customer);

            unitOfWork.Commit();
        }  // Dispose

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddDbContext<DataContext>(options =>
      {
          options.UseSqlite("Filename=UnitOfWork/database.db");
      });

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
