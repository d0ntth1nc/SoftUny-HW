using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle(5);
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CapculatePerimeter());

            var triangle = new Triangle(2, 2);
            Console.WriteLine(triangle.CalculateArea());
            Console.WriteLine(triangle.CapculatePerimeter());

            var rectangle = new Rectangle(3, 3);
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CapculatePerimeter());
        }
    }
}
