#r "nuget: Throw, 1.2.0"

using Throw;

public class AgeUtilities
{
    public int AgeInDecades(int age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Age cannot be negative", nameof(age));
        }

        if (age > 130)
        {
            throw new ArgumentException("Age cannot be greater than 130", nameof(age));
        }

        return age / 10;
    }

    public int ElegantAgeInDecades(int age)
    {
        age.Throw()
            .IfNegative()
            .IfGreaterThan(130);

        return age / 10;
    }
}
