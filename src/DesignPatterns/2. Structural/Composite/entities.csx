// Component
public abstract class Food
{
    public string Name { get; set; }
    public virtual decimal Price { get; set; }

    protected Food(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString() => $"{Name}: {Price}";
}

// Leaf
public class Ingredient : Food
{
    public Ingredient(string name, decimal price) : base(name, price) { }
}

// Composite
public class CompositeBurger : Food
{
    private readonly List<Food> _items;
    public override decimal Price => _items.Sum(item => item.Price);

    public CompositeBurger(string name, decimal price = 0) : base(name, price)
    {
        _items = new List<Food>();
    }

    public void Add(Food food) => _items.Add(food);
    public void Remove(Food food) => _items.Remove(food);
}
