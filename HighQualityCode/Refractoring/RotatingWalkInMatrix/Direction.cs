
namespace RotatingWalkInMatrix
{
    internal struct Direction
    {
        public Direction(int y, int x) : this()
        {
            this.Y = y;
            this.X = x;
        }

        public int Y { get; set; }
        public int X { get; set; }
    }
}
