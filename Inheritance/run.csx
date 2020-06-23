// Inheritance
// --------------------------------
// Description: 'is-a' relationship
// --------------------------------
// UML: Square    -----|> Shape
//      Rectangle -----|> Shape
//      Circle    -----|> Shape
// --------------------------------

#load "entities.csx"

Shape[] shapes = { new Rectangle(10, 12), new Square(5), new Circle(3) };

foreach (var shape in shapes)
{
    Console.Write($"{shape}. Area: {Shape.GetArea(shape)}, " + $"Perimeter: {Shape.GetPerimeter(shape)}");

    var rect = shape as Rectangle;
    if (rect != null)
    {
        Console.Write($", Is Square: {rect.IsSquare()}, Diagonal: {rect.Diagonal}\n");
        continue;
    }

    var sq = shape as Square;
    if (sq != null)
    {
        Console.Write($", Diagonal: {sq.Diagonal}\n");
        continue;
    }
}
