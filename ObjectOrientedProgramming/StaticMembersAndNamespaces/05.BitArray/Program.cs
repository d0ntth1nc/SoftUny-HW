using System;
using System.Text;

namespace _05.BitArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitArr = new BitArray(100000);
            bitArr[99999] = 1;
            Console.WriteLine(bitArr);
        }
    }
}