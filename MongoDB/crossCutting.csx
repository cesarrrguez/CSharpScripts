#load "settings.csx"
#load "data.csx"
#load "services.csx"
#load "controllers.csx"
#load "interfaces.csx"

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public static class IoC
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IDbSettings>(sp =>
           sp.GetRequiredService<IOptions<DbSettings>>().Value);

        services.AddScoped<DataContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserController, UserController>();

        return services;
    }
}
