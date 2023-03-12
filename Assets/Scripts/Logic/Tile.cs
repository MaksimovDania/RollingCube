#nullable enable

namespace Logic
{
    public interface Tile : Updatable
    {
        public abstract Rule Rule { get; }
    }

    public interface DiceTile : Tile
    {
        public Dice Dice { get; }
        public Match Match { get; }
        public DiceTile WithDice(Dice dice);
        public DiceTile WithMatch(Match match);
    }

    public interface BonusTile : Tile
    {
        public Bonus? Bonus { get; }
        public BonusTile WithBonus(Bonus bonus);
    }

    public interface ObjectTile : Tile
    {
        public abstract bool Solid { get; }
    }
}
