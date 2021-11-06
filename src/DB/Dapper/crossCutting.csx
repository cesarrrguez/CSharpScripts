#load "data.csx"
#load "services.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Application
        services.AddScoped<IUserService, UserService>();

        // Infrastructure - Data
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IConnectionFactory, ConnectionFactory>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
