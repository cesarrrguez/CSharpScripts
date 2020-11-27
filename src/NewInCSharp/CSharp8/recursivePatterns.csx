foreach (var animal in GetFlyingAnimals())
{
    WriteLine(animal);
}

public class Animal
{
    public string Name { get; set; }
    public bool IsFlying { get; set; }
}

public static IEnumerable<string> GetFlyingAnimals()
{
    var animals = new List<Animal>()
    {
        new Animal() { Name = "Lion", IsFlying = false},
        new Animal() { Name = "Eagle", IsFlying = true},
        new Animal() { Name = "Dog", IsFlying = false},
        new Animal() { IsFlying = true}
    };

    foreach (var animal in animals)
    {
        if (animal is Animal { IsFlying: true, Name: string name })
        {
            yield return animal.Name;
        }
    }
}
