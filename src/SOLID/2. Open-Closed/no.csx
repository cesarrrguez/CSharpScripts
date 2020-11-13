public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
}

public static class AreaCalculator
{
    public static void CalculateArea(Rectangle rectangle)
    {
        if (rectangle == null) throw new ArgumentNullException(nameof(rectangle));

        var area = rectangle.Width * rectangle.Height;

        WriteLine($"Rectangle area: {area}");
    }
}
