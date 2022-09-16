#load "interfaces.csx"

using Microsoft.Extensions.Logging;

public class HomeController : IHomeController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task StartAsync()
    {
        _logger.LogInformation("Home controller is starting");
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}
