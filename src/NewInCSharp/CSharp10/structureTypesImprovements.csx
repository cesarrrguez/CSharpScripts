public struct Rectangle
{
    public int Width { get; init; }
    public int Height { get; init; }

    public Rectangle() // C# 10
    {
        Width = 0;
        Height = 0;
    }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
}

var rectangle = new Rectangle(420, 69);
var newOne = rectangle with { Width = 420 }; // C# 10
