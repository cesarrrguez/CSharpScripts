#load "entities.csx"

// Builder
public interface ICarBuilder
{
    string Colour { get; set; }
    int NumDoors { get; set; }

    Car Build();
}
