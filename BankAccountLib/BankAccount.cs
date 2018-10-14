using System;

namespace BankAccountLib
{
    /// <summary>
    /// Bank Account demo class.
    /// src: https://docs.microsoft.com/en-us/visualstudio/test/sample-project-for-creating-unit-tests?view=vs-2017
    /// </summary>
    public class BankAccount
    {
        private string _customerName;
        private double _balance;
        private bool _frozen = false;

        public string CustomerName
        {
            get { return _customerName; }
        }

        public double Balance
        {
            get { return _balance; }
        }

        public BankAccount(string customerName, double balance)
        {
            _customerName = customerName;
            _balance = balance;
        }

        public void Debit(double amount)
        {
            if (_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            _balance += amount; // intentionally incorrect code
        }

        public void Credit(double amount)
        {
            if (_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            _balance += amount;
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