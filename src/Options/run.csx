#load "services.csx"
#load "utils.csx"

#r "nuget: Microsoft.Extensions.Options, 5.0.0"
#r "nuget: Microsoft.Extensions.Options.ConfigurationExtensions, 5.0.0"
#r "nuget: Microsoft.Extensions.Configuration, 5.0.0"
#r "nuget: Microsoft.Extensions.Configuration.Json, 5.0.0"
#r "nuget: Microsoft.Extensions.Configuration.Binder, 5.0.0"
#r "nuget: Microsoft.Extensions.DependencyInjection, 5.0.0"

using Microsoft.Extensions.Options;
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

        services.Configure<EmailConfiguration>(_configuration.GetSection("EmailService"));
        services.PostConfigure<EmailConfiguration>(config =>
        {
            if (string.IsNullOrWhiteSpace(config.SmtpServer))
            {
                throw new Exception("SmtpServer is required");
            }
        });
        services.AddScoped<IEmailService, EmailService>();

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
