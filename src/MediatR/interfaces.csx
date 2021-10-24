#load "dtos.csx"
#load "entities.csx"
#load "commands.csx"

public interface ICustomerRepository
{
    Task Create(Customer customer);
    Task<Customer> GetById(int customerId);
    Task<IEnumerable<Customer>> GetAll();
}

public interface ICustomerService
{
    Task Create(CreateCustomerCommand createCustomerCommand);
    Task<CustomerDto> GetById(int customerId);
    Task<IEnumerable<CustomerDto>> GetAll();
}
