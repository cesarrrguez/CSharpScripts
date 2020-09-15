var point = new Point();
point.X = 13;
point.Y = 21;

WriteLine(point);

public struct Point
{
    public double X { get; set; } // readonly by default
    public double Y { get; set; } // readonly by default
    public readonly double Distance => Math.Sqrt((X * X) + (Y * Y));

    public readonly override string ToString() =>
        $"({X}, {Y}) is {Distance} from the origin";

    // public readonly void Translate(int xOffset, int yOffset)
    // {
    //     X += xOffset; // Error
    //     Y += yOffset; // Error
    // }
}
