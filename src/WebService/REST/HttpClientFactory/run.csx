#load "services.csx"

#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"
#r "nuget: Microsoft.Extensions.Http, 3.1.0"

// Call App entry point
using Microsoft.Extensions.DependencyInjection;

App.Run();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        // Get post service
        var postService = _serviceProvider.GetService<IPostService>();

        // Get posts
        for (int i = 1; i <= 100; i++)
        {
            var post = postService.GetPost(i);
            WriteLine($"{post.Result}\n");
        }

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

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
