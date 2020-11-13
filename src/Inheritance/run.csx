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
