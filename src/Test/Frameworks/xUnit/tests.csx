#load "services.csx"

using Xunit;

public class FactorialServiceTests
{
    private readonly FactorialService _sut;

    public FactorialServiceTests()
    {
        _sut = new FactorialService();
    }

    [Fact]
    public async Task Calculate_ShouldReturnOne_WhenNumberIsZero()
    {
        // Arrange
        const int number = 0;

        // Act
        var result = _sut.Calculate(number);

        // Assert
        Assert.Equal(1, result);

        await Task.Delay(0).ConfigureAwait(false);
    }

    [Fact]
    public async Task Calculate_ShouldReturn120_WhenNumberIsFive()
    {
        // Arrange
        const int number = 5;

        // Act
        var result = _sut.Calculate(number);

        // Assert
        Assert.Equal(120, result);

        await Task.Delay(0).ConfigureAwait(false);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(5, 120)]
    public async Task Calculate_ShouldEqualTheirEqualTheory(int number, int expected)
    {
        // Arrange
        // Act
        var result = _sut.Calculate(number);

        // Assert
        Assert.Equal(expected, result);

        await Task.Delay(0).ConfigureAwait(false);
    }
}
