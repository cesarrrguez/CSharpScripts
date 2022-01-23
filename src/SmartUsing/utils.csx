#load "logging.csx"

using Microsoft.Extensions.Logging;

// Extensions
// ------------------------------------------------------------

public static IDisposable TimedOperation<T>(this ILogger<T> logger, string message, params object[] args)
{
    return new TimedLogOperation<T>(logger, LogLevel.Information, message, args);
}
