public interface IAggregateRoot { }

public class Entity
{
    public int Id { get; private set; }
}

public class Order : Entity, IAggregateRoot
{
    public string Product { get; private set; }
    public int Units { get; private set; }

    public Order(string product, int units)
    {
        if (string.IsNullOrWhiteSpace(product)) throw new ArgumentNullException(nameof(product));
        if (units < 1) throw new ArgumentException(nameof(units));

        Product = product;
        Units = units;
    }

    public override string ToString()
    {
        return $"Order. Id: {Id}, Product: {Product}, Units: {Units}";
    }
}

public class Customer : Entity, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Customer(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"User. Id: {Id}, FirstName: {FirstName}, LastName: {LastName}";
    }
}
