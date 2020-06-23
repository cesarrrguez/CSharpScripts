public class Customer
{
    private string _name;
    private Order _order;

    public Customer(string name)
    {
        _name = name;
    }

    public void AddOrder(Order order)
    {
        if (order != null)
            _order = order;
    }

    public override string ToString()
    {
        string result = $"Customer. Name: {_name}";

        if (_order != null)
            result += $"\n{_order}";
        else
            result += "\n";

        return result;
    }
}

public class Order
{
    private Guid _id;
    private DateTime _date;

    public Order(Guid id, DateTime date)
    {
        _id = id;
        _date = date;
    }

    public override string ToString() => $"Order. Id: {_id}, Date: {_date}";
}
