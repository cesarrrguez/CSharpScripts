#load "interfaces.csx"
#load "services.csx"
#load "controllers.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderController, OrderController>();

        return services;
    }
}
