#load "interfaces.csx"
#load "entities.csx"
#load "services.csx"

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CustomerServiceTests
{
    private static CustomerService _sut;
    private static ICustomerRepository _customerRepositoryStub;

    [ClassInitialize()]
    public static void Setup()
    {
        _customerRepositoryStub = new CustomerRepositoryStub();

        _sut = new CustomerService(_customerRepositoryStub);
    }

    [TestMethod]
    public async Task GetByIdAsync_ShouldReturnNothing_WhenCustomerDoesNotExits()
    {
        // Arrange
        var customerId = Guid.NewGuid();

        // Act
        var customer = await _sut.GetByIdAsync(customerId).ConfigureAwait(false);

        // Assert
        Assert.IsNull(customer);
    }
}

public class CustomerRepositoryStub : ICustomerRepository
{
    public Task<CustomerDto> CreateAsync(CustomerDto customer) => throw new NotImplementedException();

    public Task<CustomerDto> GetByIdAsync(Guid id) => Task.FromResult<CustomerDto>(null);

    public Task<IEnumerable<CustomerDto>> GetAllAsync() => throw new NotImplementedException();
}
