using _01.Point3D;
using System;

namespace _02.DistanceCalculator
{
    public static class DistanceCalculator
    {
        public static double Calculate(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(
                Math.Pow(p2.X - p1.X, 2) +
                Math.Pow(p2.Y - p1.Y, 2) +
                Math.Pow(p2.Z - p1.Z, 2));
        }
    }
}
