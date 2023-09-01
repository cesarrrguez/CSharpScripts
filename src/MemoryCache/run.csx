#load "services.csx"

#r "nuget: Microsoft.Extensions.Caching.Memory, 3.1.0"
#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"

using Microsoft.Extensions.DependencyInjection;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        // Get post service
        var postService = _serviceProvider.GetService<IPostService>();

        // Get posts
        for (int i = 1; i <= 10; i++)
        {
            var post = await postService.GetAsync(1);
            WriteLine($"{post}\n");
        }

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        // Memory cache
        services.AddMemoryCache();

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
