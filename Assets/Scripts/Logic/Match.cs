#nullable enable

namespace Logic
{
    public enum Match
    {
        NEVER,
        TOP,
        ALWAYS,
    }

    public static class MatchMethods
    {
        public static bool Test(this Match self, Dice first, Dice second)
        {
            switch (self)
            {
                case Match.NEVER:
                    return false;
                case Match.TOP:
                    return first.PositiveY == second.PositiveY;
                case Match.ALWAYS:
                    return true;
                default:
                    throw new System.NotSupportedException();
            }
        }
    }
}
