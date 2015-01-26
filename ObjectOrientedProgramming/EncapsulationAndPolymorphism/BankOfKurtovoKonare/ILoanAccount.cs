using System;
namespace BankOfKurtovoKonare
{
    interface ILoanAccount
    {
        decimal CalculateInterest(int months);
        void Withdraw(decimal money);
    }
}
