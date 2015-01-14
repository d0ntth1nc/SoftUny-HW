using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 100;
            int numbersNeeded = 10;
            Stack<int> numbers = new Stack<int>();
            numbers.Push(1);
            do
            {
                try
                {
                    Console.Write("Enter number #{0}: ", numbers.Count);
                    numbers.Push(ReadNumber(numbers.Peek(), max - numbersNeeded + numbers.Count));
                }
                catch
                {
                    Console.WriteLine("Invalid number! Try again!");
                }
            } while (numbers.Count <= numbersNeeded);
        }

        private static int ReadNumber(int start, int end)
        {
            int numba = int.Parse(Console.ReadLine());
            if (numba <= start || numba >= end)
            {
                throw new ArgumentOutOfRangeException();
            }
            return numba;
        }
    }
}
