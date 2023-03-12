#nullable enable

using Logic;
using UnityEngine;

public sealed class AboveGround : Rule
{
    public override void Test(Board board, Position position)
    {
        position.Y = 0;
        if (!(board[position] is GroundTile))
        {
            // TODO
        }
    }
}

public sealed class NoMatching : Rule
{
    public readonly int XOffset;
    public readonly int ZOffset;

    public NoMatching(int xOffset, int zOffset) => (XOffset, ZOffset) = (xOffset, zOffset);

    public override void Test(Board board, Position position)
    {
        var first = (board[position] as DiceTile)!;
        if (board[position + new Position(XOffset, 0, ZOffset)] is DiceTile second)
        {
            if (first.Match.Test(first.Dice, second.Dice))
            {
                // TODO
            }
        }
    }
}

public static class Useful
{
    public static Vector3 ToVector3(this Position position) =>
        new Vector3(position.X, position.Y, position.Z);
}
