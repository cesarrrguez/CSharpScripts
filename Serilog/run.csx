#load "controllers.csx"

#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"
#r "nuget: Microsoft.Extensions.Logging, 3.1.0"
#r "nuget: Serilog.Extensions.Logging, 3.0.1"
#r "nuget: Serilog.Sinks.Console, 3.1.1"
#r "nuget: Serilog.Sinks.File, 4.1.0"

using Serilog;
using Serilog.Events;
using Microsoft.Extensions.DependencyInjection;

// Call App entry point
App.Run();

public class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        var path = Path.Combine(Directory.GetCurrentDirectory(), @"Serilog\Log\log-.txt");

        Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.Console()
             .WriteTo.File(path, rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information)
             .CreateLogger();

        Log.Information("Application is starting");

        var homeController = _serviceProvider.GetRequiredService<IHomeController>();
        homeController.Run();

        // Simple values
        var count = 456;
        Log.Debug("Retrieved {Count} records", count);

        // Collections
        var array = new[] { "Apple", "Pear", "Orange" };
        Log.Debug("In my bowl I have {Fruit}", array);

        var dictionary = new Dictionary<string, int> { { "Apple", 1 }, { "Pear", 5 } };
        Log.Debug("In my bowl I have {Fruit}", dictionary);

        // Objects
        var sensorInput = new { Latitude = 25, Longitude = 134 };
        Log.Debug("Processing {@SensorInput}", sensorInput);

        int a = 10, b = 0;
        try
        {
            Log.Warning("Dividing {A} by {B}", a, b);
            Console.WriteLine(a / b);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Something went wrong");
        }
        finally
        {
            Log.Information("Application is Closing!");
            Log.CloseAndFlush();
        }

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        // Logging
        services.AddLogging(options =>
        {
            options.AddSerilog();
        });

        // IoC
        services.AddScoped<IHomeController, HomeController>();

        _serviceProvider = services.BuildServiceProvider();
    }

    private static void DisposeServices()
    {
        if (_serviceProvider == null) return;

        if (_serviceProvider is IDisposable)
        {
            ((IDisposable)_serviceProvider).Dispose();
        }
    }
}
