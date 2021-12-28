#load "interfaces.csx"
#load "entities.csx"
#load "services.csx"

using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CustomerServiceTests
{
    private static CustomerService _sut;
    private static ICustomerRepository _customerRepositoryMock;
    private static ILoggingService _loggerMock;

    [ClassInitialize()]
    public static void Setup()
    {
        _customerRepositoryMock = Substitute.For<ICustomerRepository>();
        _loggerMock = Substitute.For<ILoggingService>();

        _sut = new CustomerService(_customerRepositoryMock, _loggerMock);
    }

    [TestMethod]
    public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExits()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        const string customerName = "César Rodríguez";
        var customerDto = new CustomerDto
        {
            Id = customerId.ToString(),
            FullName = customerName
        };

        _customerRepositoryMock.GetByIdAsync(customerId).Returns(customerDto);

        // Act
        var customer = await _sut.GetByIdAsync(customerId).ConfigureAwait(false);

        // Assert
        Assert.AreEqual(customerId, customer.Id);
        Assert.AreEqual(customerName, customer.FullName);
    }

    [TestMethod]
    public async Task GetByIdAsync_ShouldReturnNothing_WhenCustomerDoesNotExits()
    {
        // Arrange
        _customerRepositoryMock.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // Act
        var customer = await _sut.GetByIdAsync(Guid.NewGuid()).ConfigureAwait(false);

        // Assert
        Assert.IsNull(customer);
    }

    [TestMethod]
    public async Task GetByIdAsync_ShouldLogAppropriateMessage_WhenCustomerExits()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        const string customerName = "César Rodríguez";
        var customerDto = new CustomerDto
        {
            Id = customerId.ToString(),
            FullName = customerName
        };

        _customerRepositoryMock.GetByIdAsync(customerId).Returns(customerDto);

        // Act
        await _sut.GetByIdAsync(customerId).ConfigureAwait(false);

        // Assert
        _loggerMock.Received(1).LogInformation($"Retrieved a customer with Id: {customerId}");
        _loggerMock.Received(0).LogInformation($"Unable to find a customer with Id: {customerId}");
    }
}
