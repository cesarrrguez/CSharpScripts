public interface IShape
{
    double GetArea();
}

public class Square : IShape
{
    public double Side { get; set; }
    public double GetArea() => Math.Pow(Side, 2);
}

public class Circle : IShape
{
    public double Radius { get; set; }
    public double GetArea() => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
}

public class AreaCalculator_OCP
{
    public static void CalculateArea(IShape shape)
    {
        var area = shape.GetArea();

        Console.WriteLine($"{shape.GetType().Name} area: {area}");
    }
}
