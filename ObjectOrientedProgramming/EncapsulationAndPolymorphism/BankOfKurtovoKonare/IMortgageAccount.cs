using System;
namespace BankOfKurtovoKonare
{
    interface IMortgageAccount
    {
        decimal CalculateInterest(int months);
        void Withdraw(decimal money);
    }
}
