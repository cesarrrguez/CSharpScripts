#load "data.csx"
#load "interfaces.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // Infrastructure
        services.AddScoped<IDataContext, DataContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
