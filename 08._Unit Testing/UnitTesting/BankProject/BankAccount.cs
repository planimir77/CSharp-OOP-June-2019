using System;

namespace BankProject
{
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal balance)
        {
            this.Balance = balance;
        }

        public decimal Balance
        {
            get { return this.balance;}
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance can not by negative");
                }

                this.balance = value;
            }
        }

        public void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw  new ArgumentException("Sum must be bigger then zero");
            }

            this.Balance += sum;
        }

        public void Withdraw(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum must be bigger then zero");
            }

            this.Balance -= sum;
        }
    }
}
