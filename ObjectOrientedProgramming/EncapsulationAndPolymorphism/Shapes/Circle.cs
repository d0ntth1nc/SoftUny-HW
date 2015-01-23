using System;

namespace Shapes
{
    public class Circle : BasicShape
    {
        public Circle(double r)
            : base(r * 2, r * 2) { }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Width / 2, 2);
        }

        public override double CapculatePerimeter()
        {
            return Math.PI * this.Width;
        }
    }
}
