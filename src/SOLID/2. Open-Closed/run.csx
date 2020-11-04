// OCP (Open/Closed Principle)
// ------------------------------------------------------------------
// A class should be open for extension, but closed for modification.
// ------------------------------------------------------------------

#load "no.csx"
#load "yes.csx"

// No
var rectangle = new Rectangle
{
    Width = 30,
    Height = 60
};

AreaCalculator.CalculateArea(rectangle);

// Yes
var square = new Square
{
    Side = 50
};

var circle = new Circle
{
    Radius = 30
};

AreaCalculator_OCP.CalculateArea(square);
AreaCalculator_OCP.CalculateArea(circle);
