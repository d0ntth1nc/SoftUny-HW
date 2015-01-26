using System;
namespace BankOfKurtovoKonare
{
    interface IDepositAccount
    {
        decimal CalculateInterest(int months);
    }
}
