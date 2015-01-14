using _01.Point3D;
using System;

namespace _03.Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = new Path3D(
                new Point3D(1, 2, 3),
                new Point3D(2, 3, 4),
                new Point3D(3, 4, 5));

            Storage.SavePath(path);
            Console.WriteLine(Storage.LoadPaths()[0].Points[0]);
        }
    }
}