#load "interfaces.csx"
#load "entities.csx"
#load "data.csx"

using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Data Infrastructure Tests
[TestClass]
public class UserRepositoryTests
{
    private static IUserRepository _userRepository;

    [ClassInitialize()]
    public static void Setup(TestContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        _userRepository = new UserRepository(TestDataContext.Context);
    }

    [TestMethod]
    public async Task Given_UserId_1_Expected_NotNull()
    {
        var result = await _userRepository.Get(1).ConfigureAwait(false);

        result.Should().NotBeNull();
    }

    [TestMethod]
    public async Task Given_UserId_2_Expected_Null()
    {
        var result = await _userRepository.Get(2).ConfigureAwait(false);

        result.Should().BeNull();
    }
}

[TestClass]
public static class InitRepositoryTests
{
    [AssemblyInitialize()]
    public static void Setup(TestContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

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
