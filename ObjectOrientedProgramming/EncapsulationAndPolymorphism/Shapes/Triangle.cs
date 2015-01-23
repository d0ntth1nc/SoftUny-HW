using System;

namespace Shapes
{
    public class Triangle : BasicShape
    {
        public Triangle(double width, double height)
            : base(width, height) { }

        public override double CalculateArea()
        {
            return (this.Width * this.Height) / 2;
        }

        public override double CapculatePerimeter()
        {
            double sideLength =
                Math.Sqrt(Math.Pow(this.Width / 2, 2) + Math.Pow(this.Height, 2));
            return sideLength * 2 + this.Width;
        }
    }
}
