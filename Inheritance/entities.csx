public abstract class Shape
{
    protected int Id { get; set; }
    public abstract double Area { get; }
    public abstract double Perimeter { get; }

    public Shape(int id)
    {
        Id = id;
    }

    public virtual string Draw() => $"Is a {nameof(Shape)}";
    public string GetName() => nameof(Shape);
    public static double GetArea(Shape shape) => shape.Area;
    public static double GetPerimeter(Shape shape) => shape.Perimeter;

    public override string ToString() => $"{Id}. {GetType().Name}";
}

public sealed class Square : Shape
{
    public double Side { get; }
    public double Diagonal => Math.Round(Math.Sqrt(2) * Side, 2);
    public override double Area => Math.Pow(Side, 2);
    public override double Perimeter => Side * 4;

    public Square(int id, double length) : base(id)
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

    public Rectangle(int id, double length, double width) : base(id)
    {
        Length = length;
        Width = width;
    }

    public bool IsSquare() => Length == Width;
    public override string Draw() => $"{base.Draw()}, Is a {nameof(Circle)}";
}

public class Circle : Shape
{
    public double Radius { get; }
    public double Diameter => Radius * 2;
    public double Circumference => Perimeter;
    public override double Area => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
    public override double Perimeter => Math.Round(Math.PI * 2 * Radius, 2);

    public Circle(int id, double radius) : base(id)
    {
        Radius = radius;
    }

    public override string Draw() => $"Is a {nameof(Circle)}";
    public new string GetName() => nameof(Circle);
}
