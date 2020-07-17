#load "entities.csx"
#load "middleware.csx"

#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var separator = new string(Enumerable.Repeat('-', 15).ToArray());

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

// Add User
Console.WriteLine("Add User:");
Console.WriteLine(separator);
await userService.RegisterNewUser(user);
var users = await userService.GetAllUsers();
PrintUsers(users);

// Update User
Console.WriteLine("\nUpdate User:");
Console.WriteLine(separator);
user.UpdateAge(33);
user.AddEmail("james.wilson_33.@hotmail.com");
await userService.EditUser(user);
users = await userService.GetAllUsers();
PrintUsers(users);

// Get User
Console.WriteLine("\nGet User:");
Console.WriteLine(separator);
user = await userService.GetUser(user.Id);
Console.WriteLine(user);

// Delete User
Console.WriteLine("\nDelete User:");
Console.WriteLine(separator);
await userService.DeleteUser(user);
users = await userService.GetAllUsers();
PrintUsers(users);

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlite("Filename=EntityFrameworkCore/database.db");
    });

    IoC.AddRegistration(services);
}

public void Configure(ServiceProvider serviceProvider)
{
    var dataContext = serviceProvider.GetService<DataContext>();
    dataContext.Database.EnsureCreated();
}

public void PrintUsers(IEnumerable<User> users)
{
    if (users == null || !users.Any())
    {
        Console.WriteLine("No users");
    }
    else
    {
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}
