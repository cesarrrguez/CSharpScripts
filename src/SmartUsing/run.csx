#load "../../packages.csx"

#load "services.csx"

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        // Get post service
        var postService = _serviceProvider.GetService<IPostService>();

        // Get post
        var post = await postService.GetAsync(21);
        WriteLine($"{post}\n");

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        // Logging
        services.AddLogging(options => options.AddConsole());

        // Http Client
        services.AddHttpClient("API", client => client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"));

        // IoC
        services.AddScoped<IPostService, PostService>();

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
