#load "services.csx"
#load "data.csx"
#load "mappers.csx"
#load "commands.csx"
#load "behaviors.csx"

#r "nuget: MediatR, 9.0.0"
#r "nuget: MediatR.Extensions.Microsoft.DependencyInjection, 9.0.0"

#r "nuget: AutoMapper 10.1.1"
#r "nuget: AutoMapper.Extensions.Microsoft.DependencyInjection, 8.1.1"

#r "nuget: FluentValidation, 10.3.3"

#r "nuget: Microsoft.Extensions.Logging, 3.1.0"
#r "nuget: Microsoft.Extensions.Logging.Console, 3.1.0"
#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"

using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using FluentValidation;

// Call App entry point
App.Run();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        var customerService = _serviceProvider.GetService<ICustomerService>();

        var createCustomerTask = customerService.Create(new CreateCustomerCommand("César", "Rodríguez"));
        createCustomerTask.Wait();

        var getCustomerTask = customerService.GetById(4);
        getCustomerTask.Wait();
        var customerDto = getCustomerTask.Result;
        WriteLine($"\nCustomer with given ID is found: {customerDto.FirstName} {customerDto.LastName} - {customerDto.RegistrationDate}\n");

        var getAllCustomersTask = customerService.GetAll();
        getAllCustomersTask.Wait();
        var customers = getAllCustomersTask.Result;
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
