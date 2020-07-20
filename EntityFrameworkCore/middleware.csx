#load "data.csx"
#load "services.csx"
#load "interfaces.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // Application
        services.AddScoped<IUserService, UserService>();

        // Infrastructure
        services.AddScoped<IUnitOfWork, DataContext>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
