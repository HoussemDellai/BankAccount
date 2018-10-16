using System;
using Xunit;

namespace BankAccountLib.Xunit.UnitTests
{
    public class BankAccountTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1100;

            // Act
            sut.Credit(100);

            // Assert
            Assert.True(expected == sut.Balance);
        }
    }
}
