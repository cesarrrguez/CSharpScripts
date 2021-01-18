public class Rectangle
{
    public double Length { get; }
    public double Width { get; }
    public double Area => Length * Width;

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override string ToString() => $"Rectangle. Length={Length}, Width={Width}, Area={Area}";

    public static bool operator <(Rectangle rectangle1, Rectangle rectangle2)
    {
        return new RectangleComparer().Compare(rectangle1, rectangle2) < 0;
    }

    public static bool operator >(Rectangle rectangle1, Rectangle rectangle2)
    {
        return new RectangleComparer().Compare(rectangle1, rectangle2) > 0;
    }
}

public class RectangleComparer : IComparer<Rectangle>
{
    public int Compare(Rectangle rectangle1, Rectangle rectangle2)
    {
        if (rectangle1.Area > rectangle2.Area) return 1;

        if (rectangle1.Area < rectangle2.Area) return -1;

        return 0;
    }
}
