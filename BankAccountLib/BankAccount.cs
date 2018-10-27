using System;

namespace BankAccountLib
{
    /// <summary>
    /// Bank Account demo class.
    /// src: https://docs.microsoft.com/en-us/visualstudio/test/sample-project-for-creating-unit-tests?view=vs-2017
    /// </summary>
    public class BankAccount
    {
        private bool _frozen = false;

        public string CustomerName { get; }
        public double Balance { get; private set; }

        public BankAccount(string customerName, double balance)
        {
            CustomerName = customerName;
            Balance = balance;
        }

        public void Credit(double amount)
        {
            if (_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0 || amount >= int.MaxValue - Balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            Balance += amount;
        }

        public void Debit(double amount)
        {
            if (_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            Balance += amount; // intentionally incorrect code
        }

        private void FreezeAccount()
        {
            _frozen = true;
        }

        private void UnfreezeAccount()
        {
            _frozen = false;
        }
    }
}