#load "interfaces.csx"
#load "entities.csx"
#load "data.csx"

using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UserRepositoryTests
{
    private static IUserRepository _sut;

    [ClassInitialize()]
    public static void Setup()
    {
        _sut = new UserRepository(TestDataContext.Context);
    }

    [TestMethod]
    public async Task GetByIdAsync_ShouldReturnUser_WhenUserExits()
    {
        // Arrange
        const int userId = 1;

        // Act
        var result = await _sut.GetByIdAsync(userId).ConfigureAwait(false);

        // Assert
        result.Should().NotBeNull();
    }

    [TestMethod]
    public async Task GetByIdAsync_ShouldReturnNothing_WhenUserDoesNotExits()
    {
        // Arrange
        const int userId = 2;

        // Act
        var result = await _sut.GetByIdAsync(userId).ConfigureAwait(false);

        // Assert
        result.Should().BeNull();
    }
}

[TestClass]
public static class InitRepositoryTests
{
    [AssemblyInitialize()]
    public static void Setup()
    {
        TestDataContext.PrepareContext();
    }
}

// Test Context
public static class TestDataContext
{
    public static DataContext Context;

    public static void PrepareContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "dataDB").Options;

        Context = new DataContext(options);

        PrepareUsers();

        Context.SaveChanges();
    }

    private static void PrepareUsers()
    {
        Context.Add(new User()
        {
            Id = 1,
            FirstName = "Michael",
            LastName = "Brown"
        });
    }
}
