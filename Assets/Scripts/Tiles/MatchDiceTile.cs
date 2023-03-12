#nullable enable

using Logic;
using UnityEngine;

public class MatchDiceTile : MonoBehaviour, DiceTile
{
    public Rule Rule { get; private set; }
    public Dice Dice { get; private set; }
    public Match Match { get; private set; }

    public MatchDiceTile()
    {
        Rule = new Rule.And(new Rule[] {
            new AboveGround(),
            new NoMatching(-1,  0),
            new NoMatching( 0,  1),
            new NoMatching( 1,  0),
            new NoMatching( 0, -1),
        });
        Match = Match.NEVER;
    }

    public void TimePassed(double delta) { }

    public DiceTile WithDice(Dice dice)
    {
        Dice = dice;
        return this;
    }

    public DiceTile WithMatch(Match match)
    {
        Match = match;
        return this;
    }
}
