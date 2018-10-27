using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankAccountLib.Nunit.UnitTests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        [Category("Credit")]
        public void Credit_ValidAmount_IncrementBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1100;

            // Act
            sut.Credit(100);
            var actual = sut.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Debit")]
        public void Debit_ValidAmount_DecrementBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 900;

            // Act
            sut.Debit(100);

            // Assert
            Assert.AreEqual(expected, sut.Balance, "Check Debit method impl");
        }

        /// <summary>
        /// Should the code just return when the Amount = 0 ?
        /// It depends on the use case.
        /// </summary>
        [Test]
        [Category("Credit")]
        public void Credit_AmountZero_NotChangeBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
            var expected = 1000;

            // Act
            sut.Credit(0);
            var actual = sut.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Credit")]
        public void Credit_MaxAmount_ThrowsException()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Credit(int.MaxValue));
        }

        [Test]
        [Ignore("Bad test case to catch Exception inside the test method")]
        [Category("Debit")]
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
                Assert.AreEqual("amount", e.ParamName);
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// No equivalent to [ExpectedException(typeof(ArgumentOutOfRangeException))]
        /// </summary>
        [Test]
        [Category("Debit")]
        public void Debit_AmountBiggerThanBalance_ThrowsException()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Debit(2000));
        }

        [TestCase(1000, 100, 1100)]
        [TestCase(1000, 200, 1200)]
        [TestCase(1000, 300, 1300)]
        [Test]
        [Category("Credit")]
        public void Credit_ValidAmount_IncrementBalance_TestCase(double balance, double amount, double expected)
        {
            // Arrange
            var sut = new BankAccount("Adam", balance);

            // Act
            sut.Credit(amount);
            var actual = sut.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(nameof(GetData))]
        [Category("Credit")]
        public void Credit_ValidAmount_IncrementBalance_TestCaseSource(double balance, double amount, double expected)
        {
            // Arrange
            var sut = new BankAccount("Adam", balance);

            // Act
            sut.Credit(amount);
            var actual = sut.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { 1, 1, 2 },
                new object[] { 14, 1, 15 },
                new object[] { 14, 1, 15 }
            };
        }

        [SetUp]
        public void RunBeforeTest()
        {
        }

        [TearDown]
        public void RunAfterTest()
        {
        }

        [OneTimeSetUp]
        public void RunOnceBeforeTest()
        {
        }

        [OneTimeTearDown]
        public void RunOnceAfterTest()
        {
        }
    }
}
