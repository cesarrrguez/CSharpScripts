// Product
public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int NumDoors { get; set; }
    public string Colour { get; set; }

    public Car(string brand, string model, string colour, int numDoors)
    {
        Brand = brand;
        Model = model;
        Colour = colour;
        NumDoors = numDoors;

        if (numDoors == 0) throw new ArgumentException(nameof(numDoors));
    }

    public override string ToString() => $"Brand: {Brand}, Model: {Model}, NumDoors: {NumDoors}, Colour: {Colour}";
}
