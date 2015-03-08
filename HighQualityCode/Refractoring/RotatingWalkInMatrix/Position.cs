using System;

namespace RotatingWalkInMatrix
{
    internal struct Position : IEquatable<Position>
    {
        public Position(int y, int x) : this()
        {
            this.Y = y;
            this.X = x;
        }

        public int Y { get; set; }
        public int X { get; set; }

        public bool Equals(Position other)
        {
            return this.Y == other.Y && this.X == other.X;
        }
    }
}
