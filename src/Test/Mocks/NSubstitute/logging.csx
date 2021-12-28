#load "interfaces.csx"

using Microsoft.Extensions.Logging;

public class Logger : ILoggingService
{
    private readonly ILogger _logger;

    public Logger(ILogger<Logger> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void LogInformation(string message, params object[] parameters)
    {
        _logger.LogInformation(message, parameters);
    }
}
