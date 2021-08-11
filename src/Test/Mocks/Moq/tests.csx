#load "interfaces.csx"
#load "entities.csx"
#load "services.csx"

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CustomerServiceTests
{
    private static CustomerService _sut;
    private static Mock<ICustomerRepository> _customerRepositoryMock;
    private static Mock<ILoggingService> _loggerMock;

    [ClassInitialize()]
    public static void Setup()
    {
        _customerRepositoryMock = new Mock<ICustomerRepository>();
        _loggerMock = new Mock<ILoggingService>();

        _sut = new CustomerService(_customerRepositoryMock.Object, _loggerMock.Object);
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

        _customerRepositoryMock.Setup(x => x.GetByIdAsync(customerId))
            .ReturnsAsync(customerDto);

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
        _customerRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(() => null);

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

        _customerRepositoryMock.Setup(x => x.GetByIdAsync(customerId))
            .ReturnsAsync(customerDto);

        // Act
        await _sut.GetByIdAsync(customerId).ConfigureAwait(false);

        // Assert
        _loggerMock.Verify(x => x.LogInformation($"Retrieved a customer with Id: {customerId}"), Times.Once);
        _loggerMock.Verify(x => x.LogInformation($"Unable to find a customer with Id: {customerId}"), Times.Never);
    }
}
