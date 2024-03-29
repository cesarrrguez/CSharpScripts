#load "interfaces.csx"

using CSharpFunctionalExtensions;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void Create(Customer customer)
    {
        _customerRepository.Create(customer);
    }

    public Maybe<Customer> Get(Guid customerId)
    {
        // Business logic stuff here

        return _customerRepository.Get(customerId);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customerRepository.GetAll();
    }
}
