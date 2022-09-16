#load "entities.csx"

public interface IOrderService : IDisposable
{
    Task AddAsync(OrderRequest orderRequest);
}

public interface IOrderController : IDisposable
{
    Task<OrderResponse> AddAsync(OrderRequest orderRequest);
}
