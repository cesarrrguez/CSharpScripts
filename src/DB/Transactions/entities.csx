public class Order
{
    public int Id { get; set; }
    public string Product { get; }
    public int Units { get; }

    public int CustomerId { get; set; }

    public Order(string product, int units)
    {
        if (units < 1) throw new ArgumentException(nameof(units));

        Product = product ?? throw new ArgumentNullException(nameof(product));
        Units = units;
    }
}

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; }
    public string LastName { get; }

    public Customer(string firstName, string lastName)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }
}

public class OrderRequest
{
    public Order Order { get; }
    public Customer Customer { get; }

    public OrderRequest(Order order, Customer customer)
    {
        Order = order ?? throw new ArgumentNullException(nameof(order));
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
    }
}

public class OrderResponse
{
    public bool Success { get; set; }
}
