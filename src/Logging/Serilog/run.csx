#load "../../../packages.csx"

#load "controllers.csx"
#load "utils.csx"

using Serilog;
using Serilog.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    [SuppressMessage("csharp", "RCS1118", Justification = "Intentional error")]
    public static async Task RunAsync()
    {
        ConfigureServices();

        var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), @"Log\log-.txt");

        Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.Console()
             .WriteTo.File(path, restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day)
             .CreateLogger();

        Log.Information("Application is starting");

        var homeController = _serviceProvider.GetRequiredService<IHomeController>();
        await homeController.StartAsync();

        // Simple values
        const int count = 456;
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
            WriteLine(a / b);
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
        services.AddLogging(options => options.AddSerilog());

        // IoC
        services.AddScoped<IHomeController, HomeController>();

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
