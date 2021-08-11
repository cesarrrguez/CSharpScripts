#load "entities.csx"
#load "dtos.csx"

public interface ICustomerRepository
{
    Task<CustomerDto> CreateAsync(CustomerDto customer);
    Task<CustomerDto> GetByIdAsync(Guid id);
    Task<IEnumerable<CustomerDto>> GetAllAsync();
}

public interface ICustomerService
{
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer> GetByIdAsync(Guid id);
    Task<List<Customer>> GetAllAsync();
}

public interface ILoggingService
{
    void LogInformation(string message, params object[] parameters);
}
