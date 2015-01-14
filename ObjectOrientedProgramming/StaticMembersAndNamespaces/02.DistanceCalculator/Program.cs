using _01.Point3D;
using System;

namespace _02.DistanceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point3D(1, 2, 3);
            var p2 = new Point3D(2, 3, 1);
            Console.WriteLine(DistanceCalculator.Calculate(p1, p2));
        }
    }
}
