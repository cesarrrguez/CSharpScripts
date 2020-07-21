#load "entities.csx"
#load "configurations.csx"
#load "data.csx"

#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// Configure services
var services = new ServiceCollection();
ConfigureServices(services);

// Build service provider
var serviceProvider = services.BuildServiceProvider();

// Get data context
var dataContext = serviceProvider.GetService<DataContext>();
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

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlite("Filename=UnitOfWork/database.db");
    });

    DependencyInjectionConfig.AddDependencyInjectionConfiguration(services);
}
