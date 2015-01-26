using System;

namespace BankOfKurtovoKonare
{
    public abstract class Account : BankOfKurtovoKonare.IAccount
    {
        private decimal balance = 0;
        private double interestRate = 0;
        private Customer customer = null;

        public Account(Customer customer, decimal balance = 0, double interestRate = 0)
        {
            this.balance = balance;
            this.InterestRate = interestRate;
            this.Customer = customer;
        }

        public Customer Customer
        {
            get { return this.customer; }
            set
            {
                if (value == null) throw new ArgumentNullException("Customer cannot be null!");
                this.customer = value;
            }
        }

        public double InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Interest rate cannot be negative number!");
                this.interestRate = value;
            }
        }

        public decimal Balance
        {
            get { return this.balance; }
        }

        public virtual void Deposit(decimal money)
        {
            if (money <= 0) throw new ArgumentOutOfRangeException("Cannot deposit negative money!");
            this.balance += money;
        }

        public virtual void Withdraw(decimal money)
        {
            if (money > this.balance) throw new InvalidOperationException("U cannot withdraw more money than your balance!");
            this.balance -= money;
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (months < 0) throw new ArgumentOutOfRangeException("Please enter positive value!");
            return this.balance * (decimal)(1 + this.InterestRate * months);
        }
    }
}