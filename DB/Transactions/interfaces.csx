#load "entities.csx"

public interface IOrderService : IDisposable
{
    void Add(OrderRequest orderRequest);
}

public interface IOrderController : IDisposable
{
    OrderResponse Add(OrderRequest orderRequest);
}
