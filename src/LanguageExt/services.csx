#load "interfaces.csx"

using LanguageExt;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public void Create(Customer customer)
    {
        _customerRepository.Create(customer);
    }

    public Option<Customer> Get(Guid customerId)
    {
        // Business logic stuff here

        return _customerRepository.Get(customerId);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customerRepository.GetAll();
    }
}
