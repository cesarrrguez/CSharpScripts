#load "interfaces.csx"

using Microsoft.Extensions.Logging;

public class HomeController : IHomeController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Run()
    {
        _logger.LogInformation("Home controller is running");
    }
}
