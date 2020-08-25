// Inheritance
// ------------------------------------------------------------------------------------------
// Description: 'is-a' relationship
// --------------------------------
// UML: Square    -----|> Shape
//      Rectangle -----|> Shape
//      Circle    -----|> Shape
// ------------------------------------------------------------------------------------------
// Keywords:
// ------------------------------------------------------------------------------------------
// Abstract class: Classes that cannot be instantiated.
// Sealed class: Class that cannot be extended.
// Abstract method: Method that is declared without an implementation. Abstract class needed.
// Virtual method: Default base method implementation.
// Override method: Implementation of derived class.
// New method: Redefinition of base class at derived class.
// base: Call to parent property, field or method.
// : base: Call to parent constructor.
// Protected: Accesible only from class and subclasses.
// ------------------------------------------------------------------------------------------

#load "entities.csx"

Shape[] shapes = { new Rectangle(1, 10, 12), new Square(2, 5), new Circle(3, 3) };

foreach (var shape in shapes)
{
    Console.WriteLine(shape);
    Console.WriteLine($"Area: {Shape.GetArea(shape)}");
    Console.WriteLine($"Perimeter: {Shape.GetPerimeter(shape)}");
    Console.WriteLine($"Draw: {shape.Draw()}"); // Virtual
    Console.WriteLine($"Name: {shape.GetName()}");

    // Rectangle
    var rectangle = shape as Rectangle;
    if (rectangle != null)
    {
        Console.WriteLine($"Is Square: {rectangle.IsSquare()}");
        Console.WriteLine($"Diagonal: {rectangle.Diagonal}");
        Console.WriteLine();

        continue;
    }

    // Square
    var square = shape as Square;
    if (square != null)
    {
        Console.WriteLine($"Diagonal: {square.Diagonal}");
        Console.WriteLine();

        continue;
    }

    // Circle
    var circle = shape as Circle;
    if (circle != null)
    {
        Console.WriteLine($"Name: {circle.GetName()}"); // New
        Console.WriteLine();

        continue;
    }
}
