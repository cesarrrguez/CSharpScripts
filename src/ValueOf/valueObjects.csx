#load "exceptions.csx"

using ValueOf;

public class Celsius : ValueOf<double, Celsius>
{
    private const double AbsoluteZeroInCelsius = -273.15;

    protected override void Validate()
    {
        if (Value < AbsoluteZeroInCelsius)
        {
            throw new TemperatureBelowAbsoluteZeroException(Value);
        }
    }
}
