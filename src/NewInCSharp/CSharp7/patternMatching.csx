// Is-expressions with patterns
WriteLine("Is-expressions with patterns:");
int value;
object input = 7;
if (input is int number)
{
    value = number;
}

WriteLine(value);

// Switch statements with patterns
WriteLine("\nSwitch statements with patterns:");
var person = (Name: "James", Age: 21); // This is a tuple

switch (person)
{
    case (_, 21) p when p.Name == "James":
        WriteLine("Yes");
        break;

    default:
        WriteLine("No");
        break;
}

WriteLine("\nSwitch statements with patterns II:");
var bird = new Bird("Eagle");
var fish = new Fish("Shark");
Animal animal = bird;

switch (animal)
{
    case Bird bird1:
        bird1.Fly();
        break;
    case Fish fish1:
        fish1.Swim();
        break;
}

public abstract class Animal
{
    public string Name { get; }
    protected Animal(string name) => Name = name;
}
public class Bird : Animal
{
    public Bird(string name) : base("Bird " + name) { }
    public void Fly() => WriteLine($"{Name} is flying");
}
public class Fish : Animal
{
    public Fish(string name) : base("Fish " + name) { }
    public void Swim() => WriteLine($"{Name} is swimming");
}
