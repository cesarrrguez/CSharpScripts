#load "services.csx"

using Xunit;
using FluentAssertions;

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
        result.Should().Be(1);

        await Task.FromResult(0);
    }

    [Fact]
    public async Task Calculate_ShouldReturn120_WhenNumberIsFive()
    {
        // Arrange
        const int number = 5;

        // Act
        var result = _sut.Calculate(number);

        // Assert
        result.Should().Be(120);

        await Task.FromResult(0);
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
        result.Should().Be(expected);

        await Task.FromResult(0);
    }
}
