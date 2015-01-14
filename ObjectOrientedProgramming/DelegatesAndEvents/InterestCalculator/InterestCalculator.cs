using System;

namespace InterestCalculator
{
    class InterestCalculator
    {
        private int money;
        private double interest;
        private int years;
        private Func<int, double, int, double> calculator;

        public InterestCalculator(int money, double interest, int years, Func<int, double, int, double> calculator)
        {
            this.money = money;
            this.interest = interest;
            this.years = years;
            this.calculator = calculator;
        }

        public double Calculate()
        {
            return calculator(money, interest, years);
        }
    }
}
