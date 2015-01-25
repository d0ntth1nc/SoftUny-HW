
using System;
namespace BankOfKurtovoKonare
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance = 0, double interestRate = 0)
            : base(customer, balance, interestRate) { }

        public override void Withdraw(decimal money)
        {
            throw new InvalidOperationException("Loan account cannot withdraw money!");
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer.Type == CustomerType.Individual)
            {
                months -= 3;
            }
            else
            {
                months -= 2;
            }
            if (months <= 0)
            {
                return 0;
            }
            return base.CalculateInterest(months);
        }
    }
}