using System;

namespace Customer
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            var cust = new Customer("Aleksandar", "Nikolaev", "Nikolave", 9305123509, "Sofia", 089999999,
                "email@email.com", CustomerType.Diamond, new Payment("Bugatti", 1000000));
            var cloned = (Customer)cust.Clone();
            Console.WriteLine(cust == cloned);
            Console.WriteLine(object.ReferenceEquals(cust, cloned));
        }
    }
}
