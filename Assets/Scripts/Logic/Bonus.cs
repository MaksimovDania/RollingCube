#nullable enable

namespace Logic
{
    public interface Bonus : Updatable
    {
        public abstract double? Duration { get; }
        public abstract uint Usages { get; }
    }
}
