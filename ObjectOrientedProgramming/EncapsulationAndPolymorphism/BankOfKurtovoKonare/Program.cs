using System;

namespace BankOfKurtovoKonare
{
    class Program
    {
        static void Main(string[] args)
        {
            var me = new Customer("Alex", CustomerType.Individual);
            var acc = new DepositAccount(me, 2000, 0.2);
            acc.Deposit(500);
            acc.Withdraw(600);
            Console.WriteLine("Balance: {0}", acc.Balance);
            Console.WriteLine("Interest: {0}", acc.CalculateInterest(15));
            Console.WriteLine("========");

            var loanAcc = new LoanAccount(me, 3000, 0.4);
            try
            {
                loanAcc.Withdraw(500);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
