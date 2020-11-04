#load "crossCutting.csx"

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        IoC.RegisterServices(services);
    }
}
