#load "entities.csx"
#load "services.csx"
#load "data.csx"

#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0-preview3.19554.8"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var separator = new string(Enumerable.Repeat('-', 15).ToArray());

var user = new User("James", "Wilson", 30);
user.AddAddress("Wall Street", "New York", "New York State", "0123456789");
user.AddEmail("james.wilson@gmail.com");

// Configure services
var services = new ServiceCollection();
ConfigureServices(services);

// Get data context
var dataContext = services.BuildServiceProvider().GetService<DataContext>();
dataContext.Database.EnsureCreated();

// Create service
var userService = new UserService(new UserRepository(dataContext));

// Add
Console.WriteLine("Add User:");
Console.WriteLine(separator);
userService.RegisterNewUser(user);
var users = userService.GetAllUsers();
PrintUsers(users);

// Update
Console.WriteLine("\nUpdate User:");
Console.WriteLine(separator);
user.UpdateAge(33);
user.AddEmail("james.wilson_33.@hotmail.com");
userService.EditUser(user);
users = userService.GetAllUsers();
PrintUsers(users);

// Get
Console.WriteLine("\nGet User:");
Console.WriteLine(separator);
user = userService.GetUser(user.Id);
Console.WriteLine(user);

// Delete
Console.WriteLine("\nDelete User:");
Console.WriteLine(separator);
userService.DeleteUser(user);
users = userService.GetAllUsers();
PrintUsers(users);

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlite("Filename=EntityFrameworkCore/database.db");
    });
}

public void PrintUsers(List<User> users)
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
