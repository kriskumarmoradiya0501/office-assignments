using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MvcXunitDemo.Services;

namespace MvcXunitDemo.Tests
{
    public class PasswordValidatorTests
    {
        [Fact]
        public void ValidPassword_ReturnsTrue()
        {
            PasswordValidator validator = new PasswordValidator();

            bool result = validator.IsValid("Hello1");

            Assert.True(result);
        }

        [Fact]
        public void PasswordLessThan6Character_ReturnsFalse()
        {
            PasswordValidator validator = new PasswordValidator();

            bool result = validator.IsValid("Hell1");

            Assert.False(result);
        }

        [Fact]
        public void PasswordWithoutCapitalLetter_ReturnsFalse()
        {
            PasswordValidator validator = new PasswordValidator();

            bool result = validator.IsValid("hello1");

            Assert.False(result);
        }

        [Fact]
        public void PassworWithoutNumber_ReturnsFalse()
        {
            PasswordValidator validator = new PasswordValidator();

            bool result = validator.IsValid("HelloWorld");

            Assert.False(result);
        }

        [Fact]
        public void PassworWithCalpitalLetterAndNumber_ReturnsTrue()
        {
            PasswordValidator validator = new PasswordValidator();

            bool result = validator.IsValid("HelloWorld123");

            Assert.True(result);
        }

        // [Theory]
        // [InlineData("Hello1", true)]
        // [InlineData("Password123", true)]
        // [InlineData("hello1", false)]
        // [InlineData("HELLO", false)]
        // [InlineData("Hi1", false)]
        // public void Password_IsValid_ReturnsExpectedResult(
        // string password,
        // bool expected)
        // {
        //     var validator = new PasswordValidator();

        //     var result = validator.IsValid(password);

        //     Assert.Equal(expected, result);
        // }

    }
}