#nullable enable

namespace Logic
{
    public struct Position
    {
        public int X;
        public int Y;
        public int Z;

        public Position(int x, int y, int z) => (X, Y, Z) = (x, y, z);

        public static Position operator -(Position self) =>
            new Position(-self.X, -self.Y, -self.Z);

        public static Position operator +(Position first, Position second) =>
            new Position(first.X + second.X, first.Y + second.Y, first.Z + second.Z);

        public static Position operator -(Position first, Position second) =>
            new Position(first.X - second.X, first.Y - second.Y, first.Z - second.Z);

        public override string ToString()
        {
            return $"Position[X={X}, Y={Y}, Z={Z}]";
        }
    }
}
