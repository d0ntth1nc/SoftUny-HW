using System;
using System.Linq;
using System.Numerics;

namespace _05.BitArray
{
    public class BitArray
    {
        public const int MIN_SIZE = 1;
        public const int MAX_SIZE = 100000;

        private bool[] bits;

        public BitArray(int size)
        {
            if (size < MIN_SIZE || size > MAX_SIZE)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Bit array size must be less than or equal {0} and more than or equal {1}",
                        MAX_SIZE, MIN_SIZE));
            }
            this.bits = new bool[size];
        }

        public int this[int index]
        {
            get { return this.bits[index] == true ? 1 : 0; }
            set
            {
                if (value != 0 && value != 1)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Accepts only 1 or 0!"));
                }
                if (index < 0 || index > this.bits.Length - 1)
                {
                    throw new IndexOutOfRangeException(
                        string.Format("Invalid index! Please enter index between {0} and {1}", 0, this.bits.Length - 1));
                }
                this.bits[index] = value == 1 ? true : false;
            }
        }

        public override string ToString()
        {
            var range = Enumerable.Range(0, this.bits.Length);
            var resultNumbers = from i in range.AsParallel()
                                select GetPow(i);
            return resultNumbers.AsParallel().Aggregate((x, z) => x + z).ToString();
        }

        private BigInteger GetPow(int indx)
        {
            // Speed up
            if (this[indx] == 0)
            {
                return new BigInteger(0);
            }
            var range = Enumerable.Range(0, indx);
            var result = range.AsParallel().Aggregate(new BigInteger(1), (x, y) => x * 2);
            return result * this[indx];
        }
    }
}
