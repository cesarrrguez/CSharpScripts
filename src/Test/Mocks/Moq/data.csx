#load "dtos.csx"
#load "interfaces.csx"

public class CustomerRepository : ICustomerRepository
{
    public Task<CustomerDto> CreateAsync(CustomerDto customer) => throw new NotImplementedException();

    public Task<CustomerDto> GetByIdAsync(Guid id) => throw new NotImplementedException();

    public Task<IEnumerable<CustomerDto>> GetAllAsync() => throw new NotImplementedException();
}
