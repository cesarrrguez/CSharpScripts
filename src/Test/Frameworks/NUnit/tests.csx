#load "services.csx"

using NUnit.Framework;

[TestFixture]
public class FactorialServiceTests
{
    private FactorialService _sut;

    [SetUp]
    public void SetUp()
    {
        _sut = new FactorialService();
    }

    [Test]
    public async Task Calculate_ShouldReturnOne_WhenNumberIsZero()
    {
        // Arrange
        const int number = 0;

        // Act
        var result = _sut.Calculate(number);

        // Assert
        Assert.AreEqual(1, result);

        await Task.Delay(0).ConfigureAwait(false);
    }

    [Test]
    public async Task Calculate_ShouldReturn120_WhenNumberIsFive()
    {
        // Arrange
        const int number = 5;

        // Act
        var result = _sut.Calculate(number);

        // Assert
        Assert.AreEqual(120, result);

        await Task.Delay(0).ConfigureAwait(false);
    }

    [TestCase(0, 1)]
    [TestCase(5, 120)]
    public async Task Calculate_ShouldEqualTheirEqualTheory(int number, int expected)
    {
        // Arrange
        // Act
        var result = _sut.Calculate(number);

        // Assert
        Assert.AreEqual(expected, result);

        await Task.Delay(0).ConfigureAwait(false);
    }
}
