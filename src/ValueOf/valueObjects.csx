#load "exceptions.csx"

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