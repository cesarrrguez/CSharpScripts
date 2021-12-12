#load "interfaces.csx"

using CSharpFunctionalExtensions;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDictionary<Guid, Customer> _customers = new Dictionary<Guid, Customer>
    {
        { Guid.Parse("00000000-1111-2222-3333-000000000000"), new Customer
          {
              Id = Guid.Parse("00000000-1111-2222-3333-000000000000"),
              FullName = "César Rodríguez"
          }
        }
    };

    public void Create(Customer customer)
    {
        _customers.TryAdd(customer.Id, customer);
    }

    public Maybe<Customer> Get(Guid customerId)
    {
        var found = _customers.TryGetValue(customerId, out var customer);

        return found ? customer : Maybe<Customer>.None;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customers.Values;
    }
}
