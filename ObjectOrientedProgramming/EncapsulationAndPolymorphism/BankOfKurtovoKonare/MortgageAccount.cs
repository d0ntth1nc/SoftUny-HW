using System;

namespace BankOfKurtovoKonare
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance = 0, double interestRate = 0)
            : base(customer, balance, interestRate) { }

        public override void Withdraw(decimal money)
        {
            throw new InvalidOperationException("Mortgage account cannot withdraw money!");
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0;
            if (this.Customer.Type == CustomerType.Company)
            {
                if (months > 12)
                {
                    interest = base.CalculateInterest(12) / 2;
                    interest += base.CalculateInterest(months - 12);
                }
                else
                {
                    interest = base.CalculateInterest(months);
                }
            }
            else
            {
                if (months - 6 > 0)
                {
                    interest = base.CalculateInterest(months - 6);
                }
            }
            return interest;
        }
    }
}