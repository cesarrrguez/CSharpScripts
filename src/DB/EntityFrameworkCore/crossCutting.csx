#load "interfaces.csx"
#load "controllers.csx"
#load "services.csx"
#load "data.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // UI
        services.AddTransient<IUserController, UserController>();

        // Application
        services.AddTransient<IUserService, UserService>();

        // Infrastructure
        services.AddTransient<IUnitOfWork, DataContext>();
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }
}
