#load "interfaces.csx"

// Concrete Builder
public class FerrariBuilder : ICarBuilder
{
    public string Colour { get; set; }
    public int NumDoors { get; set; }

    public Car Build() => NumDoors == 2 ? new Car("Ferrari", "488 Spider", Colour, NumDoors) : null;
}
