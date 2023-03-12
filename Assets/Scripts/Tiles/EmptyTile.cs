#nullable enable

using Logic;

public class EmptyTile : BonusTile
{
    public Rule Rule { get { return new Rule.Dummy(); } }
    public Bonus? Bonus { get { return null; } }

    public void TimePassed(double delta) { }
    public BonusTile WithBonus(Bonus bonus)
    {
        throw new System.NotImplementedException();
    }
}
