#load "services.csx"
#load "controllers.csx"
#load "interfaces.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static IServiceCollection AddRegistration(IServiceCollection services)
    {
        // Singleton objects are the same for every object and every request.
        // Transient objects are always different; a new instance is provided to every controller and every service.
        // Scoped objects are the same within a request, but different across different requests.

        services.AddSingleton<IUserService, UserService>();
        // services.AddTransient<IUserService, UserService>();     
        // services.AddScoped<IUserService, UserService>();

        services.AddScoped<IUserController, UserController>();

        return services;
    }
}
