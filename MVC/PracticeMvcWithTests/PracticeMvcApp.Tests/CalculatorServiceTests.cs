using Xunit;
using Microsoft.Extensions.Logging.Abstractions;
using PracticeMvcApp.Services;

namespace PracticeMvcApp.Tests;

public class CalculatorServiceTests
{
    [Fact]
    public void Add_ReturnsCorrectSum()
    {
        var calculator = new CalculatorService(NullLogger<CalculatorService>.Instance);

        var result = calculator.Add(5, 7);

        Assert.Equal(12, result);
    }
}

public class PasswordValidatorTests
{
    private readonly PasswordValidator _validator = new();

    [Fact]
    public void Password_WithFewerThanEightCharacters_FailsLengthCheck()
    {
        Assert.False(_validator.HasMinimumLength("Abcd2345"));
        Console.WriteLine("Length must be greater than 8 charecters ");
    }

    [Fact]
    public void Password_WithoutCapitalLetter_FailsCapitalCheck()
    {
        Assert.False(_validator.HasCapitalLetter("password1"));
    }

    [Fact]
    public void Password_WithoutNumber_FailsNumberCheck()
    {
        Assert.False(_validator.HasNumber("Password"));
    }

    [Fact]
    public void Password_WithAllRules_IsValid()
    {
        Assert.False(_validator.IsValid("Password1"));
    }
}
