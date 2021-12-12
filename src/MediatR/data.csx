#load "entities.csx"
#load "interfaces.csx"

public class CustomerRepository : ICustomerRepository
{
    private readonly IList<Customer> _customers = new List<Customer>
    {
        { new Customer { Id = 1, FirstName ="James", LastName="Rodríguez", RegistrationDate = DateTime.Now.AddDays(-10) }
        },
        { new Customer { Id = 2, FirstName="George", LastName="Lucas", RegistrationDate = DateTime.Now.AddDays(-20) }
        },
        { new Customer { Id = 3, FirstName="Olivia", LastName="Jones", RegistrationDate = DateTime.Now.AddDays(-30) }
        }
    };

    public async Task Create(Customer customer)
    {
        await Task.Delay(TimeSpan.FromSeconds(0.5)).ConfigureAwait(false);

        customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;

        _customers.Add(customer);
    }

    public async Task<Customer> GetById(int customerId)
    {
        await Task.Delay(TimeSpan.FromSeconds(0.5)).ConfigureAwait(false);

        return _customers.SingleOrDefault(customer => customer.Id == customerId);
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.5)).ConfigureAwait(false);

        return _customers;
    }
}
