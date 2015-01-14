using System;

namespace AsynchronousTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new AsyncTimer(() => Console.WriteLine("Halo"), 10, 1000);
            timer.Start();
            while (!timer.IsReady)
            {

            }
        }
    }
}