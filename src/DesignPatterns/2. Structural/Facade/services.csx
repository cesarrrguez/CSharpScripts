#load "entities.csx"

// Facade
public class BuyService
{
    private readonly Warehouse _warehouse;
    private readonly Payment _payment;
    private readonly Order _order;

    public BuyService()
    {
        _warehouse = new Warehouse();
        _payment = new Payment();
        _order = new Order();
    }

    public void Buy()
    {
        if (_warehouse.CheckStock() && _payment.CheckPayment())
        {
            _order.Send();
        }
    }
}
