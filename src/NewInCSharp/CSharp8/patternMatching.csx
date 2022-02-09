// Switch expressions

WriteLine("Switch expressions:");
var value1 = 14;
var value2 = 0;
var operation = Operation.Divide;
var result = Calculator(value1, value2, operation);
WriteLine($"The result of '{operation}' '{value1}' and '{value2}' is '{result}'");

public enum Operation { Add, Substract, Multiply, Divide }

public double Calculator(double value1, double value2, Operation operation) =>
    operation switch
    {
        Operation.Add => value1 + value2,
        Operation.Substract => value1 - value2,
        Operation.Multiply => value1 * value2,
        Operation.Divide => value1 / value2,
        _ => throw new NotSupportedException(),
    };

WriteLine("\nSwitch expressions II:");
var bird = new Bird("Eagle");
var fish = new Fish("Shark");
Animal animal = bird;

string action = animal switch
{
    Bird b => b.Fly(),
    Fish f when f.Name == "Fish Shark" => f.Swim(),
    _ => "Unknown"
};
WriteLine(action);

public abstract class Animal
{
    public string Name { get; }
    protected Animal(string name) => Name = name;
}
public class Bird : Animal
{
    public Bird(string name) : base("Bird " + name) { }
    public string Fly() => $"{Name} is flying";
}
public class Fish : Animal
{
    public Fish(string name) : base("Fish " + name) { }
    public string Swim() => $"{Name} is swimming";
}

// Property patterns
WriteLine("\nProperty patterns:");
var address = new Address("MI");
var product = new Product("Mickey Mouse", 7.89M);
WriteLine($"Product '{product.Name}' price with taxes for '{address.State}' are '{ComputeSalesTax(address, 45)}'");

public class Address
{
    public string State { get; }

    public Address(string state) => State = state;
}

public class Product
{
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price) => (Name, Price) = (name, price);
}

public decimal ComputeSalesTax(Address location, decimal salePrice) =>
    location switch
    {
        { State: "WA" } => salePrice * 0.06M,
        { State: "MN" } => salePrice * 0.075M,
        { State: "MI" } => salePrice * 0.05M,
        _ => 0M
    };

// Tuple patterns
WriteLine("\nTuple patterns:");
var first = "rock";
var second = "scissors";
WriteLine($"'{first}' against '{second}' are '{RockPaperScissors(first, second)}'");

public string RockPaperScissors(string first, string second) =>
    (first, second) switch
    {
        ("rock", "paper") => "rock is covered by paper. Paper wins.",
        ("rock", "scissors") => "rock breaks scissors. Rock wins.",
        ("paper", "rock") => "paper covers rock. Paper wins.",
        ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
        ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
        ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
        (_, _) => "tie"
    };

// Positional patterns
WriteLine("\nPositional patterns:");
var point = new Point(13, 78);
WriteLine($"Point: {point} -> Quadrant: {GetQuadrant(point)}");

public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y) => (X, Y) = (x, y);

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);

    public override string ToString() => $"({X}, {Y})";
}

public enum Quadrant { Unknown, Origin, One, Two, Three, Four, OnBorder }

public Quadrant GetQuadrant(Point point) =>
    point switch
    {
        (0, 0) => Quadrant.Origin,
        var (x, y) when x > 0 && y > 0 => Quadrant.One,
        var (x, y) when x < 0 && y > 0 => Quadrant.Two,
        var (x, y) when x < 0 && y < 0 => Quadrant.Three,
        var (x, y) when x > 0 && y < 0 => Quadrant.Four,
        var (_, _) => Quadrant.OnBorder,
        _ => Quadrant.Unknown
    };
