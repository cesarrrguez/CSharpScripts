public class Customer
{
    private readonly string _name;
    private Order _order;

    public Customer(string name)
    {
        _name = name;
    }

    public void AddOrder(Order order)
    {
        if (order != null)
        {
            _order = order;
        }
    }

    public override string ToString()
    {
        var result = $"Customer. Name: {_name}";

        if (_order != null)
        {
            result += $"\n{_order}";
        }
        else
        {
            result += "\n";
        }

        return result;
    }
}

public class Order
{
    private readonly Guid _id;
    private readonly DateTime _date;

    public Order(Guid id, DateTime date)
    {
        _id = id;
        _date = date;
    }

    public override string ToString() => $"Order. Id: {_id}, Date: {_date}";
}
