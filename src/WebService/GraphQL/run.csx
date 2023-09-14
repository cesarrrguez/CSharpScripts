#load "../../../packages.csx"

#load "controllers.csx"
#load "configurations.csx"

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
        await postController.GetAllAsync(options);

        // Get
        await postController.GetAsync(21);

        // Create
        var postInput = new PostInput() { Title = "Hello", Body = "World!" };
        await postController.CreateAsync(postInput);

        // Update
        await postController.UpdateAsync(21, postInput);

        // Delete
        await postController.DeleteAsync(21);

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
