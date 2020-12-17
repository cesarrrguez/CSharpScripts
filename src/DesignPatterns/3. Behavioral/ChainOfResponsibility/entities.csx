#load "enums.csx"

// Handler
public abstract class Logger
{
    protected LogLevel LogLevel;
    protected Logger NextLogger;

    protected Logger(LogLevel logLevel)
    {
        LogLevel = logLevel;
    }

    public Logger SetNext(Logger nextlogger)
    {
        var lastLogger = this;

        while (lastLogger.NextLogger != null)
        {
            lastLogger = lastLogger.NextLogger;
        }

        lastLogger.NextLogger = nextlogger;
        return this;
    }

    public void Message(string message, LogLevel logLevel)
    {
        if ((logLevel & LogLevel) != 0)
        {
            WriteMessage(message);
        }
        NextLogger?.Message(message, logLevel);
    }

    protected abstract void WriteMessage(string message);
}

// Concrete Handler 1
public class ConsoleLogger : Logger
{
    public ConsoleLogger(LogLevel logLevel) : base(logLevel) { }
    protected override void WriteMessage(string message) => WriteLine("Writing to console: " + message);
}

// Concrete Handler 2
public class EmailLogger : Logger
{
    public EmailLogger(LogLevel logLevel) : base(logLevel) { }
    protected override void WriteMessage(string message) => WriteLine("Sending via email: " + message);
}

// Concrete Handler 3
public class FileLogger : Logger
{
    public FileLogger(LogLevel logLevel) : base(logLevel) { }
    protected override void WriteMessage(string message) => WriteLine("Writing to Log File: " + message);
}
