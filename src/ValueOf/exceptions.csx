public class TemperatureBelowAbsoluteZeroException : Exception
{
    public TemperatureBelowAbsoluteZeroException(double degrees)
      : base($"Temperature cannot be below absolute zero. Current value: {degrees}") { }

    public TemperatureBelowAbsoluteZeroException() { }
    public TemperatureBelowAbsoluteZeroException(string message) : base(message) { }
    public TemperatureBelowAbsoluteZeroException(string message, Exception innerException) : base(message, innerException) { }
}
