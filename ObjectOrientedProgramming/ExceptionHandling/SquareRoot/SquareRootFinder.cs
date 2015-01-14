using System;

namespace SquareRoot
{
    class SquareRootFinder
    {
        static void Main(string[] args)
        {
            try
            {
                int numba = int.Parse(Console.ReadLine());
                if (numba < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine(Math.Sqrt(numba));
            }
            catch
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
