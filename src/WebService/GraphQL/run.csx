#load "controllers.csx"
#load "configurations.csx"

#r "nuget: GraphQL.Client, 3.1.9"
#r "nuget: GraphQL.Client.Serializer.Newtonsoft, 3.1.9"
#r "nuget: Microsoft.Extensions.Logging, 3.1.0"
#r "nuget: Microsoft.Extensions.Logging.Console, 3.1.0"
#r "nuget: Microsoft.Extensions.DependencyInjection, 5.0.0"
#r "nuget: Microsoft.Extensions.Configuration, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Json, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Binder, 3.1.0"
#r "nuget: Microsoft.Extensions.Options, 3.1.0"
#r "nuget: Microsoft.Extensions.Options.ConfigurationExtensions, 3.1.0"

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        // Get post controller
        var postController = _serviceProvider.GetService<IPostController>();

        // Get all
        var pagination = new PostOptionsInputPagination() { Page = 1, Limit = 5 };
        var options = new PostOptionsInput { Paginate = pagination };
        await postController.GetAllPostsAsync(options);

        // Get
        await postController.GetPostAsync(21);

        // Create
        var postInput = new PostInput() { Title = "Hello", Body = "World!" };
        await postController.CreatePostAsync(postInput);

        // Update
        await postController.UpdatePostAsync(21, postInput);

        // Delete
        await postController.DeletePostAsync(21);

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddLogging(options => options.AddConsole());

        SettingsConfig.AddSettingsConfiguration(services);
        DependencyInjectionConfig.AddDependencyInjectionConfiguration(services);

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
