#load "../../../packages.csx"

using Throw;

public class Order
{
    public string Name { get; }
    public int Quantity { get; }
    public long Max { get; }
    public decimal UnitPrice { get; }

    public Order(string name, int quantity, long max, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"Required input {name} was empty.", nameof(name));
        }

        Name = name;

        if (quantity <= 0)
        {
            throw new ArgumentException($"Required input {quantity} cannot be zero or negative.", nameof(quantity));
        }

        Quantity = quantity;

        if (max == 0)
        {
            throw new ArgumentException($"Required input {max} cannot be zero.", nameof(max));
        }

        Max = max;

        if (unitPrice < 0)
        {
            throw new ArgumentException($"Required input {unitPrice} cannot be zero or negative.", nameof(unitPrice));
        }

        UnitPrice = unitPrice;
    }
}

public class ElegantOrder
{
    public string Name { get; }
    public int Quantity { get; }
    public long Max { get; }
    public decimal UnitPrice { get; }

    public ElegantOrder(string name, int quantity, long max, decimal unitPrice)
    {
        Name = name.ThrowIfNull().IfWhiteSpace();
        Quantity = quantity.Throw().IfEquals(0).IfNegative();
        Max = max.Throw().IfEquals(0);
        UnitPrice = unitPrice.Throw().IfNegative();
    }
}
