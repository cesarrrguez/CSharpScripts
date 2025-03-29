public class Rectangle
{
    public int Width { get; init; }
    public int Height { get; init; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void Deconstruct(out int width, out int height)
    {
        width = Width;
        height = Height;
    }
}

var rectangle = new Rectangle(100, 200);

(int w, int h) = rectangle;

// C# 9
int widthCSharp9;
int heightCSharp9;
(widthCSharp9, heightCSharp9) = rectangle;

// C# 10
int widthCSharp10;
//int heightCSharp10;
(widthCSharp10, int heightCSharp10) = rectangle;
