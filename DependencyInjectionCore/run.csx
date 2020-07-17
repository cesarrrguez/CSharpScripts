#load "middleware.csx"
#load "controllers.csx"

#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"

using Microsoft.Extensions.DependencyInjection;

// Configure services
var services = new ServiceCollection();
ConfigureServices(services);

// Build service provider
var serviceProvider = services.BuildServiceProvider();

// Get user controller
var userController = serviceProvider.GetService<IUserController>();

// Print output
Console.WriteLine(userController.Get());

public void ConfigureServices(IServiceCollection services)
{
    IoC.AddRegistration(services);
}
