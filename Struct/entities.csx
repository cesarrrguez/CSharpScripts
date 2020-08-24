public struct Point
{
    public double X { get; private set; }
    public double Y { get; private set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static void IncreasePoint(Point point, double increment)
    {
        point.X += increment;
        point.Y += increment;
    }

    public override string ToString() => $"({X}, {Y})";
}
