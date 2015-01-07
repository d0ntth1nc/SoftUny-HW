using System;

namespace FractionCalculator
{
    internal struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            :this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            long lcm = LCM(left.Denominator, right.Denominator);
            long leftNumerator = (lcm / left.Denominator) * left.Numerator;
            long rightNumerator = (lcm / right.Denominator) * right.Numerator;
            return new Fraction( leftNumerator + rightNumerator, lcm );
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            long lcm = LCM(left.Denominator, right.Denominator);
            long leftNumerator = (lcm / left.Denominator) * left.Numerator;
            long rightNumerator = (lcm / right.Denominator) * right.Numerator;
            return new Fraction(leftNumerator - rightNumerator, lcm);
        }

        private static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        private static long LCM(long a, long b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }

        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0) throw new ArgumentException("Denominator cannot be 0!");

                this.denominator = value;
            }
        }

        public override string ToString()
        {
            return ((double)this.Numerator / this.Denominator).ToString();
        }
    }
}
