#load "data.csx"
#load "services.csx"
#load "interfaces.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static IServiceCollection AddRegistration(IServiceCollection services)
    {
        services.AddScoped<IDataContext, DataContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
