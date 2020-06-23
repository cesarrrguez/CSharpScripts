public abstract class Shape
{
    public abstract double Area { get; }
    public abstract double Perimeter { get; }

    public static double GetArea(Shape shape) => shape.Area;
    public static double GetPerimeter(Shape shape) => shape.Perimeter;

    public override string ToString() => GetType().Name;
}

public class Square : Shape
{
    public double Side { get; }
    public double Diagonal => Math.Round(Math.Sqrt(2) * Side, 2);
    public override double Area => Math.Pow(Side, 2);
    public override double Perimeter => Side * 4;

    public Square(double length)
    {
        Side = length;
    }
}

public class Rectangle : Shape
{
    public double Length { get; }
    public double Width { get; }
    public double Diagonal => Math.Round(Math.Sqrt(Math.Pow(Length, 2) + Math.Pow(Width, 2)), 2);
    public override double Area => Length * Width;
    public override double Perimeter => 2 * Length + 2 * Width;

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public bool IsSquare() => Length == Width;
}

public class Circle : Shape
{
    public double Radius { get; }
    public double Diameter => Radius * 2;
    public override double Area => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
    public override double Perimeter => Math.Round(Math.PI * 2 * Radius, 2);
    public double Circumference => Perimeter;

    public Circle(double radius)
    {
        Radius = radius;
    }
}
