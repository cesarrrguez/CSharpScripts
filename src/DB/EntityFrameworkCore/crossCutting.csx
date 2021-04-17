#load "interfaces.csx"
#load "controllers.csx"
#load "services.csx"
#load "data.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static void RegisterServices(IServiceCollection services)
    {
        // UI
        services.AddTransient<IUserController, UserController>();

        // Application
        services.AddTransient<IUserService, UserService>();

        // Infrastructure - Data
        services.AddTransient<IUnitOfWork, DataContext>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}
