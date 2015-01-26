using System;
namespace BankOfKurtovoKonare
{
    interface IAccount
    {
        decimal Balance { get; }
        decimal CalculateInterest(int months);
        Customer Customer { get; set; }
        void Deposit(decimal money);
        double InterestRate { get; set; }
        void Withdraw(decimal money);
    }
}
