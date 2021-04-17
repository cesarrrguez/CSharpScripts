#load "interfaces.csx"
#load "services.csx"
#load "controllers.csx"

using Microsoft.Extensions.DependencyInjection;

public static class IoC
{
    public static void RegisterServices(IServiceCollection services)
    {
        // UI
        services.AddScoped<IOrderController, OrderController>();

        // Application
        services.AddScoped<IOrderService, OrderService>();
    }
}
