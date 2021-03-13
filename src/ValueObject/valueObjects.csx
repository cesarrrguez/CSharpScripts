using ValueOf;

public class Celsius : ValueOf<double, Celsius>
{
    private const double AboluteZeroInCelsius = -273.15;

    protected override void Validate()
    {
        if (Value < AboluteZeroInCelsius)
        {
            throw new TemperatureBelowAboluteZeroException(Value);
        }
    }
}

public class TemperatureBelowAboluteZeroException : Exception
{
    public TemperatureBelowAboluteZeroException(double degrees)
      : base($"Temperature cannot be below absolute zero. Current value: {degrees}") { }

    public TemperatureBelowAboluteZeroException() { }
    public TemperatureBelowAboluteZeroException(string message) : base(message) { }
    public TemperatureBelowAboluteZeroException(string message, Exception innerException) : base(message, innerException) { }
}
