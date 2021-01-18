public class Rectangle : IComparable
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

    public int CompareTo(object obj)
    {
        var temp = (Rectangle)obj;

        if (Area > temp.Area) return 1;

        if (Area < temp.Area) return -1;

        return 0;
    }

    public static bool operator <(Rectangle rectangle1, Rectangle rectangle2)
    {
        return rectangle1.CompareTo(rectangle2) < 0;
    }

    public static bool operator >(Rectangle rectangle1, Rectangle rectangle2)
    {
        return rectangle1.CompareTo(rectangle2) > 0;
    }
}
