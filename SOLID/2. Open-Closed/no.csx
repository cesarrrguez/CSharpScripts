public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
}

public static class AreaCalculator
{
    public static void CalculateArea(Rectangle rectangle)
    {
        var area = rectangle.Width * rectangle.Height;

        Console.WriteLine($"Rectangle area: {area}");
    }
}
