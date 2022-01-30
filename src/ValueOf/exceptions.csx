public class TemperatureBelowAboluteZeroException : Exception
{
    public TemperatureBelowAboluteZeroException(double degrees)
      : base($"Temperature cannot be below absolute zero. Current value: {degrees}") { }

    public TemperatureBelowAboluteZeroException() { }
    public TemperatureBelowAboluteZeroException(string message) : base(message) { }
    public TemperatureBelowAboluteZeroException(string message, Exception innerException) : base(message, innerException) { }
}
