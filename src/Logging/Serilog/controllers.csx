#load "interfaces.csx"

using Microsoft.Extensions.Logging;

public class HomeController : IHomeController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task StartAsync()
    {
        _logger.LogInformation("Home controller is starting");
        await Task.FromResult(0);
    }
}
