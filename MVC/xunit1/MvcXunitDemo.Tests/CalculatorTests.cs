using Xunit;
using MvcXunitDemo.Services;

namespace MvcXunitDemo.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(5, 5, 10)]
        [InlineData(100, 50, 150)]
        [InlineData(2, 3, 5)]
        public void Add_TwoNumbers_ReturnsCorrectResult(
                int a,
                int b,
                int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Subtract_ReturnsCorrectDifference()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Subtarct(20, 10);
            Assert.Equal(10, result);
        }

        [Fact]
        public void Multiply_ReturnsCorrectProduct()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Multiply(5, 4);
            Assert.Equal(20, result);
        }
    }
}
