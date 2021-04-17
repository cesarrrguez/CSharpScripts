#load "data.csx"
#load "interfaces.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Infrastructure - Data
        services.AddScoped<IDataContext, DataContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
