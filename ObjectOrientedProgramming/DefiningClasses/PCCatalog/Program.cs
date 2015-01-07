using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace PCCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("bg-BG");

            int computersCount = 5;
            Computer[] computers = new Computer[computersCount];
            var random = new Random();
            for (int i = 0; i < computersCount; i++)
            {
                computers[i] = new Computer("someName",
                    new Component("AMD FX8320 Processor", Convert.ToDecimal(random.NextDouble() * 1000)),
                    new Component("Asrock 990FX Extreme 3", Convert.ToDecimal(random.NextDouble() * 1000)),
                    new Component("HDD WD BLUE 1 TB", Convert.ToDecimal(random.NextDouble() * 1000)));
            }

            int index = 1;
            foreach (var computer in computers.OrderBy(x => x.Price))
            {
                Console.WriteLine("Computer #{0}", index++);
                Console.WriteLine(computer);
                Console.WriteLine();
            }
        }
    }
}
