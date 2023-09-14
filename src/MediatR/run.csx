#load "../../packages.csx"

#load "services.csx"
#load "data.csx"
#load "mappers.csx"
#load "commands.csx"
#load "behaviors.csx"

using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using FluentValidation;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        var customerService = _serviceProvider.GetService<ICustomerService>();

        await customerService.Create(new CreateCustomerCommand("César", "Rodríguez"));

        var customerDto = await customerService.GetById(4);
        WriteLine($"\nCustomer with given ID is found: {customerDto.FirstName} {customerDto.LastName} - {customerDto.RegistrationDate}\n");

        var customers = await customerService.GetAll();
        customers.ToList().ForEach(customer => WriteLine($"{customer.Id}: {customer.FirstName} {customer.LastName} - {customer.RegistrationDate}"));

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddLogging(opt => opt.AddConsole());

        services.AddMediatR(typeof(App).Assembly);

        // For all the validators, register them with dependency injection as scoped
        AssemblyScanner.FindValidatorsInAssembly(typeof(App).Assembly)
          .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddAutoMapper(typeof(DomainProfile));

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        _serviceProvider = services.BuildServiceProvider();
    }

    private static void DisposeServices()
    {
        if (_serviceProvider == null) return;

        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
