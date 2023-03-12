#nullable enable

using System.Diagnostics;

namespace Logic
{
    public struct Dice
    {
        public sbyte PositiveX;
        public sbyte PositiveY;
        public sbyte PositiveZ;
        public sbyte NegativeX { get { return (sbyte)(7 - PositiveX); } }
        public sbyte NegativeY { get { return (sbyte)(7 - PositiveY); } }
        public sbyte NegativeZ { get { return (sbyte)(7 - PositiveZ); } }

        public Dice(sbyte positiveX, sbyte positiveY, sbyte positiveZ)
        {
            Debug.Assert(positiveX >= 1 && positiveX <= 6);
            Debug.Assert(positiveY >= 1 && positiveY <= 6);
            Debug.Assert(positiveZ >= 1 && positiveZ <= 6);

            bool invalid =
                positiveX + positiveY == 7 ||
                positiveY + positiveZ == 7 ||
                positiveZ + positiveX == 7 ||
                positiveX == positiveY ||
                positiveY == positiveZ ||
                positiveZ == positiveX;

            if (invalid) throw new System.Exception($"Invalid Dice({positiveX} {positiveY} {positiveZ}");

            PositiveX = positiveX;
            PositiveY = positiveY;
            PositiveZ = positiveZ;
        }

        public Dice Step(Direction direction)
        {
            switch (direction)
            {
                case Direction.POSITIVE_Z:
                    return new Dice(PositiveX, NegativeZ, PositiveY);
                case Direction.POSITIVE_X:
                    return new Dice(PositiveY, NegativeX, PositiveZ);
                case Direction.NEGATIVE_Z:
                    return new Dice(PositiveX, PositiveZ, NegativeY);
                case Direction.NEGATIVE_X:
                    return new Dice(NegativeY, PositiveX, PositiveZ);
                default:
                    throw new System.Exception();
            }
        }

        public Dice Spin(bool clockwise)
        {
            return clockwise
                ? new Dice(PositiveZ, PositiveY, NegativeX)
                : new Dice(NegativeZ, PositiveY, PositiveX);
        }
    }
}
