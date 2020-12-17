[Flags]
public enum LogLevel
{
    None = 0,
    Info = 1,
    Debug = 2,
    Warning = 4,
    Error = 8,
    FunctionalMessage = 16,
    FunctionalError = 32,
    All = Info | Debug | Warning | Error | FunctionalMessage | FunctionalError
}
