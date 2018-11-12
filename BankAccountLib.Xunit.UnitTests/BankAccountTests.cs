using Xunit;
using System;
using System.Collections.Generic;

namespace BankAccountLib.Xunit.UnitTests
{
    public class BankAccountTests
    {
        [Fact]
        [Trait("Method", "Credit")]
        public void Credit_ValidAmount_IncrementBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1100;

            // Act
            sut.Credit(100);
            var actual = sut.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Method", "Debit")]
        public void Debit_ValidAmount_DecrementBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 900;

            // Act
            sut.Debit(100);
            var actual = sut.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Should the code just return when the Amount = 0 ?
        /// It depends on the use case.
        /// </summary>
        [Fact]
        [Trait("Method", "Credit")]
        public void Credit_AmountZero_NotChangeBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1000;

            // Act
            sut.Credit(0);
            var actual = sut.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Bad test case to catch Exception inside the test")]
        [Trait("Method", "Debit")]
        public void Debit_AmountBiggerThanBalance_ThrowsException_()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1000;
            var actual = 0.0;

            // Act
            try
            {
                sut.Debit(2000);
            }
            catch (ArgumentOutOfRangeException e)
            {
                actual = sut.Balance;

                // Assert
                Assert.Equal("amount", e.ParamName);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        [Trait("Method", "Credit")]
        public void Credit_MaxAmount_ThrowsException()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Credit(int.MaxValue));
        }

        [Fact]
        [Trait("Method", "Debit")]
        public void Debit_AmountBiggerThanBalance_ThrowsException()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1000;

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Debit(2000));
            var actual = sut.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }

        [InlineData(1000, 100, 1100)]
        [InlineData(1000, 200, 1200)]
        [InlineData(1000, 300, 1300)]
        [Theory]
        [Trait("Method", "Credit")]
        public void Credit_ValidAmount_IncrementBalance_DataRow(double balance, double amount, double expected)
        {
            // Arrange
            var sut = new BankAccount("Adam", balance);

            // Act
            sut.Credit(amount);
            var actual = sut.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }

        [MemberData(nameof(GetData))]
        [Theory]
        [Trait("Method", "Credit")]
        public void Credit_ValidAmount_IncrementBalance_MemberData(double balance, double amount, double expected)
        {
            // Arrange
            var sut = new BankAccount("Adam", balance);

            // Act
            sut.Credit(amount);
            var actual = sut.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { 1, 1, 2 },
                new object[] { 14, 1, 15 },
                new object[] { 14, 1, 15 }
            };
        }
        
        /// <summary>
        /// The equivalent to [TestInitialize] is the constructor.
        /// </summary>
        public BankAccountTests()
        {
        }
    }
}
