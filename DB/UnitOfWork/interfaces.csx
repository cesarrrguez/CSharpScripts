#load "entities.csx"

public interface IDataContext { }

public interface IUnitOfWork : IDisposable
{
    IOrderRepository OrderRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    bool Commit();
}

public interface IRepository<T> where T : IAggregateRoot { }

public interface IOrderRepository : IRepository<Order>
{
    void Add(Order order);
}

public interface ICustomerRepository : IRepository<Customer>
{
    void Add(Customer customer);
}
