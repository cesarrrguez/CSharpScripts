#load "interfaces.csx"

public class OrderController : IOrderController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<OrderResponse> AddAsync(OrderRequest orderRequest)
    {
        var response = new OrderResponse();

        try
        {
            await _orderService.AddAsync(orderRequest);
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
