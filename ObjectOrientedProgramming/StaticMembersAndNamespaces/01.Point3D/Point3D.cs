
namespace _01.Point3D
{
    public class Point3D
    {
        private static readonly Point3D coordinateSystemStartPoint =
            new Point3D();

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D() { }

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D CoordinateSystemStartingPoint
        {
            get { return coordinateSystemStartPoint; }
        }

        public override string ToString()
        {
            return string.Format("[Point3D: X = {0}, Y = {1}, Z = {2}]",
                this.X, this.Y, this.Z);
        }
    }
}
