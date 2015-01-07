using System;

namespace LaptopShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var laptop = new Laptop("Acer", 1500, battery: new Battery("LI-ION", 4, 2500, 4));
            Console.WriteLine(laptop);
        }
    }
}