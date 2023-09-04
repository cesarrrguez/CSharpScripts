#load "enums.csx"

public class Order
{
    public long Id { get; set; }
    public bool IsVerified { get; set; }
    public bool IsProcessed { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public List<LineItem> Items { get; set; } = new();
}
