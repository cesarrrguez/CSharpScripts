#load "interfaces.csx"

using System.Collections;

public class Sum : IOperation
{
    private double r = 0;

    public void Calculate(double a, double b)
    {
        r = a + b;
    }

    public void Show()
    {
        WriteLine("The result of sum is: {0}", r);
    }

    public void Check()
    {
        WriteLine("I´m inside {0}", nameof(Sum));
    }
}

public class Subtract : IOperation
{
    private double r = 0;

    public void Calculate(double a, double b)
    {
        r = a - b;
    }

    public void Show()
    {
        WriteLine("The result of substraction is: {0}", r);
    }

    public void Check()
    {
        WriteLine("I´m inside {0}", nameof(Subtract));
    }
}
