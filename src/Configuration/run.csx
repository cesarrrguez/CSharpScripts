#load "../../packages.csx"

#load "services.csx"
#load "utils.csx"

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;
    private static IConfiguration _configuration;

    public static async Task RunAsync()
    {
        Configure();
        ConfigureServices();

        var emailService = _serviceProvider.GetService<IEmailService>();
        await emailService.SendEmailAsync("to@email.com", "my subject", "My body");

        DisposeServices();
    }

    private static void Configure()
    {
        var builder = new ConfigurationBuilder()
                    .SetBasePath(FolderUtil.GetCurrentDirectoryName())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        _configuration = builder.Build();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton(_ =>
        {
            var emailConfiguration = new EmailConfiguration();
            _configuration.Bind("emailService", emailConfiguration);
            return emailConfiguration;
        })
        .AddScoped<IEmailService, EmailService>();

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
