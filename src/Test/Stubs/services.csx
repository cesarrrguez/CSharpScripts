#load "interfaces.csx"

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        var customerDto = new CustomerDto
        {
            FullName = customer.FullName
        };

        var createdCustomer = await _customerRepository.CreateAsync(customerDto);
        return MapDtoToDomain(createdCustomer);
    }

    public async Task<Customer> GetByIdAsync(Guid customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);

        if (customer == null)
        {
            return null;
        }

        return MapDtoToDomain(customer);
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        var customerDtos = (await _customerRepository.GetAllAsync()).ToList();
        return customerDtos.ConvertAll(MapDtoToDomain);
    }

    private Customer MapDtoToDomain(CustomerDto dto) => new Customer { Id = Guid.Parse(dto.Id), FullName = dto.FullName };
}
