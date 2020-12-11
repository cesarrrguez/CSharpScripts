#load "interfaces.csx"

// Concrete Implementor A
public class Logger1 : ILogger
{
    public void Info(string message) => WriteLine($"Info: {message}");
    public void Warning(string message) => WriteLine($"Warning: {message}");
}

// Concrete Implementor B
public class Logger2 : ILogger
{
    public void Info(string message) => WriteLine($"[INFO] {message}");
    public void Warning(string message) => WriteLine($"[WARN] {message}");
}
