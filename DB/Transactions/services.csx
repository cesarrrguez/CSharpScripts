#load "interfaces.csx"
#load "data.csx"

public class OrderService : IOrderService
{
    private readonly DataContext _context;

    public OrderService(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(OrderRequest orderRequest)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Customers.Add(orderRequest.Customer);
            _context.SaveChanges();

            orderRequest.Order.CustomerId = orderRequest.Customer.Id;
            _context.Orders.Add(orderRequest.Order);
            _context.SaveChanges();

            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw new Exception("Error adding order");
        }
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
