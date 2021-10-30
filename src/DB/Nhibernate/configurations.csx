#load "crossCutting.csx"
#load "mappers.csx"

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        IoC.RegisterServices(services);
    }
}

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
    }
}
