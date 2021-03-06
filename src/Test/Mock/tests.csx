#load "interfaces.csx"
#load "entities.csx"
#load "services.csx"

using Moq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Application Tests
[TestClass]
public class UserServiceTests
{
    private static IUserService _userService;

    [ClassInitialize()]
    public static void Setup()
    {
        Mock<IUserRepository> userRepository = new UserRepositoryMock().UserRepository;
        _userService = new UserService(userRepository.Object);
    }

    [TestMethod]
    public async Task Given_UserId_100_Expected_UserId_1()
    {
        var result = await _userService.GetUserAsync(100).ConfigureAwait(false);

        result.Id.Should().Be(1);
    }

    [TestMethod]
    public async Task Given_UserId_2_Expected_UserId_2()
    {
        var result = await _userService.GetUserAsync(2).ConfigureAwait(false);

        result.Id.Should().Be(2);
    }

    [TestMethod]
    public async Task GetAllUsersCount_Expected_2()
    {
        var result = await _userService.GetAllUsersAsync().ConfigureAwait(false);

        result.Count().Should().Be(2);
    }
}

// Mock Repositories
public class UserRepositoryMock
{
    public Mock<IUserRepository> UserRepository { get; }

    public UserRepositoryMock()
    {
        UserRepository = new Mock<IUserRepository>();
        Setup();
    }

    private void Setup()
    {
        UserRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(StubData.User_1);

        UserRepository.Setup(x => x.GetAsync(2)).ReturnsAsync(StubData.User_2);

        UserRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(StubData.Users);
    }
}

// Stubs
public static class StubData
{
    public static User User_1 = new User()
    {
        Id = 1,
        FirstName = "Michael",
        LastName = "Brown"
    };

    public static User User_2 = new User()
    {
        Id = 2,
        FirstName = "John",
        LastName = "Miller"
    };

    public static List<User> Users = new List<User>(new User[] { User_1, User_2 });
}
