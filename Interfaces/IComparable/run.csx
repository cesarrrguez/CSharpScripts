#load "entities.csx"

var rectangles = new Rectangle[]
{
    new Rectangle(7,5),
    new Rectangle(6,4),
    new Rectangle(4,3),
    new Rectangle(7,6),
    new Rectangle(5,7)
};

foreach (var rectangle in rectangles)
    Console.WriteLine(rectangle);

Console.WriteLine("\nSort:");
Array.Sort(rectangles);

foreach (var rectangle in rectangles)
    Console.WriteLine(rectangle);

Console.WriteLine("\nOperators:");
if (rectangles[1] < rectangles[2])
    Console.WriteLine("Rectangle 1 is smaller");

if (rectangles[2] > rectangles[1])
    Console.WriteLine("Rectangle 2 is greatter");

