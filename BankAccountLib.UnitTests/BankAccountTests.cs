using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankAccountLib.UnitTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void CreditShouldSetBalanceTo1100Test()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1100;

            // Act
            sut.Credit(100);

            // Assert
            Assert.AreEqual(expected, sut.Balance);
        }

        [TestMethod]
        public void DebitShouldSetBalanceTo900Test()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 900;

            // Act
            sut.Debit(100);

            // Assert
            Assert.AreEqual(expected, sut.Balance);
        }

        [TestMethod]
        public void DebitMoreThanBalanceShouldThrowExceptionTest()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1000;

            // Act
            try
            {
                sut.Debit(2000);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                Assert.AreEqual(e.ParamName, "amount");
                Assert.AreEqual(expected, sut.Balance);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DebitMoreThanBalanceShouldThrowExceptionAttributeTest()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);

            // Act
            sut.Debit(2000);

            // Assert
        }

        [TestMethod]
        [DataRow(1000, 100, 1100)]
        [DataRow(1000, 200, 1200)]
        [DataRow(1000, 300, 1300)]
        [DataTestMethod]
        public void CreditShouldSetBalanceTest(double balance, double amount, double expected)
        {
            // Arrange
            var sut = new BankAccount("Adam", balance);

            // Act
            sut.Credit(amount);

            // Assert
            Assert.AreEqual(expected, sut.Balance);
        }
    }
}
