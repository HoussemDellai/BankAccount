using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BankAccountLib.MsTest.UnitTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        [TestCategory("Credit")]
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
        [TestCategory("Debit")]
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
        [TestCategory("Debit")]
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
        [TestCategory("Debit")]
        public void DebitMoreThanBalanceShouldThrowExceptionAttributeTest()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);

            // Act
            sut.Debit(2000);

            // Assert
        }

        [DataRow(1000, 100, 1100)]
        [DataRow(1000, 200, 1200)]
        [DataRow(1000, 300, 1300)]
        [DataTestMethod]
        [TestCategory("Credit")]
        public void CreditShouldSetBalance_DataRowTest(double balance, double amount, double expected)
        {
            // Arrange
            var sut = new BankAccount("Adam", balance);

            // Act
            sut.Credit(amount);

            // Assert
            Assert.AreEqual(expected, sut.Balance);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        [TestCategory("Credit")]
        public void CreditShouldSetBalance_DynamicDataTest(double balance, double amount, double expected)
        {
            // Arrange
            var sut = new BankAccount("Adam", balance);

            // Act
            sut.Credit(amount);

            // Assert
            Assert.AreEqual(expected, sut.Balance);
        }

        private static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 1, 1, 2 };
            yield return new object[] { 12, 30, 42 };
            yield return new object[] { 14, 1, 15 };
        }

        [TestInitialize]
        public void RunBeforeTest()
        {
        }

        [TestCleanup]
        public void RunAfterTest()
        {
        }
    }
}
