#load "customizations.csx"

using AutoFixture;
using Xunit;

public class ProductTests
{
    [Fact]
    public async Task Create_ShouldReturnDummyProduct()
    {
        // Arrange
        IFixture fixture = new Fixture().Customize(new DummyProductCustomization());

        // Act
        var product = fixture.Create<Product>();

        // Assert
        Assert.Equal("Dummy Product", product.Name);

        await Task.Delay(0);
    }

    [Fact]
    public async Task Create_ShouldReturnExpensiveAndDummyProduct()
    {
        // Arrange
        IFixture fixture = new Fixture().Customize(new ExpensiveDummyProductCustomization());

        // Act
        var product = fixture.Create<Product>();

        // Assert
        Assert.True(product.IsExpensive());
        Assert.Equal("Dummy Product", product.Name);

        await Task.Delay(0);
    }
}

public class UserTests
{
    [Fact]
    public async Task Create_ShouldReturnUser_WithUserSpecimenBuilder()
    {
        // Arrange
        Fixture fixture = new Fixture();
        fixture.Customizations.Add(new UserSpecimenBuilder());

        // Act
        User user = fixture.Create<User>();

        // Assert
        Assert.NotNull(user);

        await Task.Delay(0);
    }

    [Fact]
    public async Task Create_ShouldReturnUser_WithMultipleSpecimenBuilder()
    {
        // Arrange
        Fixture fixture = new Fixture();
        fixture.Customizations.Add(new PasswordSpecimenBuilder());
        fixture.Customizations.Add(new EmailSpecimenBuilder());

        // Act
        User user = fixture.Create<User>();

        // Assert
        Assert.NotNull(user);

        await Task.Delay(0);
    }

    [Fact]
    public async Task Create_ShouldReturnUser_WithUserCustomization()
    {
        // Arrange
        IFixture fixture = new Fixture().Customize(new UserCustomization());

        // Act
        User user = fixture.Create<User>();

        // Assert
        Assert.NotNull(user);

        await Task.Delay(0);
    }

    [Fact]
    public async Task Create_ShouldReturnUser_WithSpanishUserCustomization()
    {
        // Arrange
        IFixture fixture = new Fixture().Customize(new SpanishUserCustomization());

        // Act
        User user = fixture.Create<User>();

        // Assert
        Assert.Equal("ES", user.Country.Name);

        await Task.Delay(0);
    }

    [Fact]
    public async Task Create_ShouldReturnUser_WithAdultUserCustomization()
    {
        // Arrange
        IFixture fixture = new Fixture().Customize(new AdultUserCustomization());

        // Act
        User user = fixture.Create<User>();

        // Assert
        Assert.True(user.IsAdult());
        Assert.Equal("ES", user.Country.Name);

        await Task.Delay(0);
    }

    [Fact]
    public async Task Create_ShouldReturnUser_WithUserWithDummyProductCustomization()
    {
        // Arrange
        IFixture fixture = new Fixture().Customize(new UserWithDummyProductCustomization());

        // Act
        User user = fixture.Create<User>();

        // Assert
        Assert.Equal("Dummy Product", user.Product.Name);

        await Task.Delay(0);
    }
}
