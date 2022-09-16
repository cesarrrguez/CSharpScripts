#load "interfaces.csx"
#load "data.csx"

public class OrderService : IOrderService
{
    private readonly DataContext _context;

    public OrderService(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddAsync(OrderRequest orderRequest)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            await _context.Customers.AddAsync(orderRequest.Customer);
            await _context.SaveChangesAsync();

            orderRequest.Order.CustomerId = orderRequest.Customer.Id;
            await _context.Orders.AddAsync(orderRequest.Order);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw new Exception("Error adding order");
        }
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
