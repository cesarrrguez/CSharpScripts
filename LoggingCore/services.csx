#load "interfaces.csx"

using System.Threading;
using Microsoft.Extensions.Logging;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public string GetName()
    {
        _logger.LogTrace("This is a trace log");
        _logger.LogDebug("This is a debug log");
        _logger.LogInformation(LoggingId.DemoCode, "This is an information log");
        _logger.LogWarning("This is a warning log");
        _logger.LogError("This is an error log");
        _logger.LogCritical("This is a critical log");

        Thread.Sleep(1000);

        return "César Rodríguez";
    }
}

public class LoggingId
{
    public const int DemoCode = 1001;
}
