#nullable enable

using Logic;
using UnityEngine;

public class MainDiceTile : MonoBehaviour, DiceTile
{
    public Rule Rule { get; private set; }
    public Dice Dice { get; private set; }
    public Match Match { get; private set; }

    public MainDiceTile()
    {
        Rule = new Rule.Dummy();
        Match = Match.TOP;
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
