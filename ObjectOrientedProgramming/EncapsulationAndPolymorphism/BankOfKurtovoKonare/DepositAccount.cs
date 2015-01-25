using System;

namespace BankOfKurtovoKonare
{
    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal balance = 0, double interestRate = 0)
            : base(customer, balance, interestRate) { }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                throw new InvalidOperationException("•	Deposit accounts have no interest if their balance is positive and less than 1000!");
            }
            return base.CalculateInterest(months);
        }
    }
}