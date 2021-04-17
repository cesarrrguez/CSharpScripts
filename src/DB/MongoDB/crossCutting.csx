#load "settings.csx"
#load "data.csx"
#load "services.csx"
#load "controllers.csx"
#load "interfaces.csx"

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public static class IoC
{
    public static void RegisterServices(IServiceCollection services)
    {
        // UI
        services.AddScoped<IUserController, UserController>();

        // Application
        services.AddScoped<IUserService, UserService>();

        // Infrastructure - Data
        services.AddSingleton<IDbSettings>(sp =>
            sp.GetRequiredService<IOptions<DbSettings>>().Value);

        services.AddScoped<DataContext>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
