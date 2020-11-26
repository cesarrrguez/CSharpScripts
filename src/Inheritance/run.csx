#load "entities.csx"

Shape[] shapes = { new Rectangle(1, 10, 12), new Square(2, 5), new Circle(3, 3) };

foreach (var shape in shapes)
{
    WriteLine(shape);
    WriteLine($"Area: {Shape.GetArea(shape)}");
    WriteLine($"Perimeter: {Shape.GetPerimeter(shape)}");
    WriteLine($"Draw: {shape.Draw()}"); // Virtual
    WriteLine($"Name: {shape.GetName()}");

    // Rectangle
    if (shape is Rectangle rectangle)
    {
        WriteLine($"Is Square: {rectangle.IsSquare()}");
        WriteLine($"Diagonal: {rectangle.Diagonal}");
        WriteLine();

        continue;
    }

    // Square
    if (shape is Square square)
    {
        WriteLine($"Diagonal: {square.Diagonal}");
        WriteLine();

        continue;
    }

    // Circle
    if (shape is Circle circle)
    {
        WriteLine($"Name: {circle.GetName()}"); // New
        WriteLine();
    }
}
