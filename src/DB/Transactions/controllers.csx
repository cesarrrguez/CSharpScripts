#load "interfaces.csx"

public class OrderController : IOrderController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    public OrderResponse Add(OrderRequest orderRequest)
    {
        var response = new OrderResponse();

        try
        {
            _orderService.Add(orderRequest);
            response.Success = true;
        }
        catch (Exception)
        {
            response.Success = false;
        }

        return response;
    }

    public void Dispose()
    {
        _orderService.Dispose();
        GC.SuppressFinalize(this);
    }
}
