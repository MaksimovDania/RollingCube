#nullable enable

namespace Logic
{
    public abstract class Rule
    {
        public sealed class Dummy : Rule
        {
            public override void Test(Board board, Position position) { }
        }

        public sealed class And : Rule
        {
            public readonly Rule[] rules;

            public And(Rule[] rules) => this.rules = rules;

            public override void Test(Board board, Position position)
            {
                System.Array.ForEach(rules, it => it.Test(board, position));
            }
        }

        public sealed class Any : Rule
        {
            public readonly Rule[] rules;

            public Any(Rule[] rules) => this.rules = rules;

            public override void Test(Board board, Position position)
            {
                // TODO
            }
        }

        // Метод должен выбрасывать ошибки, если правило не выполняется
        // Каждая ошибка должна чётко объяснять что пошло не так
        // Нужна иерархия классов, наследующихся от System.Exception
        public abstract void Test(Board board, Position position);
    }
}
