#load "services.csx"

using Xunit;

using Moq;
using Moq.AutoMock;

public class UserServiceTests
{
    [Fact]
    public async Task Print_ShouldUseRepository_WhenUsingConstructor()
    {
        // Arrange
        var repositoryMoq = new Mock<IRepository<User>>();
        var userService = new UserService(repositoryMoq.Object);

        // Act
        userService.Print();

        // Assert
        repositoryMoq.Verify(r => r.GetAll(), Times.AtLeastOnce);

        await Task.Delay(0);
    }

    [Fact]
    public async Task Print_ShouldUseRepository_WhenUsingAutoMocker()
    {
        // Arrange
        var mocker = new AutoMocker();
        var userService = mocker.CreateInstance<UserService>();
        var repositoryMoq = mocker.GetMock<IRepository<User>>();

        // Act
        userService.Print();

        // Assert
        repositoryMoq.Verify(r => r.GetAll(), Times.AtLeastOnce);

        await Task.Delay(0);
    }

    [Fact]
    public async Task Print_ShouldUseRepository_WhenUsingAutoMockerWithShortCut()
    {
        // Arrange
        var mocker = new AutoMocker();
        var userService = mocker.CreateInstance<UserService>();

        // Act
        userService.Print();

        // Assert
        mocker.Verify<IRepository<User>>(r => r.GetAll(), Times.AtLeastOnce);

        await Task.Delay(0);
    }
}
