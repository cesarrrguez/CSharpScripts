#load "entities.csx"
#load "controllers.csx"
#load "middleware.csx"

#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// Create user
var user = new User("James", "Wilson", 30);
user.AddAddress("Wall Street", "New York", "New York State", "0123456789");
user.AddEmail("james.wilson@gmail.com");

// Configure services
var services = new ServiceCollection();
ConfigureServices(services);

// Build service provider
var serviceProvider = services.BuildServiceProvider();
Configure(serviceProvider);

// Get user service
var userService = serviceProvider.GetService<IUserService>();

// Create user controller
var userController = new UserController(userService);

// Add User
await userController.Create(user);
await userController.Index();

// Update User
user.UpdateAge(33);
user.AddEmail("james.wilson_33.@hotmail.com");
await userController.Edit(user);
await userController.Index();

// Get User
await userController.Details(user.Id);

// Delete User
await userController.Delete(user);
await userController.Index();

// Dispose user service
userService.Dispose();

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlite("Filename=EntityFrameworkCore/database.db");
    });

    IoC.RegisterServices(services);
}

public void Configure(ServiceProvider serviceProvider)
{
    var dataContext = serviceProvider.GetService<DataContext>();
    dataContext.Database.EnsureCreated();
}


