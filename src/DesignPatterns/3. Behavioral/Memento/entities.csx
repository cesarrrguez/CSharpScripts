// Memento
public class ProductMemento
{
    public readonly string Name;

    public ProductMemento(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}

// Originator
public class Product
{
    public string Name { get; private set; }

    public void Set(string name)
    {
        WriteLine("Setting product name to " + name);
        Name = name;
    }

    public ProductMemento SaveToMemento()
    {
        WriteLine("Saving product to Memento");
        return new ProductMemento(Name);
    }

    public void RestoreFromMemento(ProductMemento memento)
    {
        Name = memento.Name;
        WriteLine("Name after restoring from Memento: " + Name);
    }
}
