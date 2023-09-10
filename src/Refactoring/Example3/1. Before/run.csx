public class OrderProcessor
{
    public void Process(Order order)
    {
        if (order != null)
        {
            if (order.IsVerified)
            {
                if (order.Items.Count > 0)
                {
                    if (order.Items.Count > 15)
                    {
                        throw new Exception("Ther order " + order.Id + " has too many items");
                    }

                    if (order.Status != "ReadyToProcess")
                    {
                        throw new Exception("Ther order " + order.Id + " isn´t ready to process");
                    }

                    order.IsProcessed = true;
                }
            }
        }
    }
}

public class Order
{
    public long Id { get; set; }
    public bool IsVerified { get; set; }
    public bool IsProcessed { get; set; }
    public string Status { get; set; } = string.Empty;
    public List<LineItem> Items { get; set; } = new();
}

public class LineItem
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
