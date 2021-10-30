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
        services.AddScoped<IUserController, UserController>();

        // Application
        services.AddScoped<IUserService, UserService>();

        // Infrastructure - Data
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
