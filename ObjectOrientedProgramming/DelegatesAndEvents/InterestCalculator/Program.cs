using System;

namespace InterestCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, double, int, double> simpleInterestDelegate = new Func<int, double, int, double>(GetSimpleInterest);
            Func<int, double, int, double> compoundInterestDelegate = new Func<int, double, int, double>(GetCompoundInterest);

            var calculator = new InterestCalculator(500, 5.6, 10, compoundInterestDelegate);
            Console.WriteLine("{0:0.0000}", calculator.Calculate());

            calculator = new InterestCalculator(2500, 7.2, 15, simpleInterestDelegate);
            Console.WriteLine("{0:0.0000}", calculator.Calculate());
        }

        private static double GetSimpleInterest(int money, double interest, int years)
        {
            interest /= 100;
            return money * (1 + interest * years);
        }

        private static double GetCompoundInterest(int money, double interest, int years)
        {
            int n = 12;
            interest /= 100;
            return money * Math.Pow((1 + interest / n), years * n);
        }
    }
}
