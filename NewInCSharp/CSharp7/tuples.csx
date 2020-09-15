// Create tuple
var person = (Name: "James", Age: 21);
WriteLine($"Person: {person.Name}, {person.Age}");

// Get tuple from method
var array = new int[] { 55, 67, 100, 34 };
var range = Range(array);
WriteLine($"Range: {range.Item1} - {range.Item2}");

public (int, int) Range(int[] array) => (array.Min(), array.Max());

// Deconstruct
var point = new Point(3.14, 2.71);
(double X, double Y) = point;
WriteLine($"Point: ({X} , {Y})");

public class Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y) => (X, Y) = (x, y);

    public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
}
