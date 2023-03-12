#nullable enable

using System.Collections.Generic;
using System.Diagnostics;

namespace Logic
{
    public class Level : Updatable
    {
        public struct Configuration
        {
            public struct Varying<T>
            {
                public T Min;
                public T Max;
                public T Initial;
                public T Increment;
                public T Decrement;
            }

            public double MainDiceStepPeriod;
            public double MainDiceStepPartialPeriod;
            public double MainDiceStepPhantom;
            public Varying<double> Speed;
            public Varying<uint> Power;

            public double MatchDiceFadePeriod;
        }

        public readonly Board Board;
        public readonly Configuration Config;
        private LinkedList<Direction> _directionOrder = new LinkedList<Direction>();
        private Direction? _lockedDirection = null;
        private double _movingLast = 0;
        private Position _position;
        private uint _swapRotationShift = 0;


        public readonly bool IsFinished = false;
        public bool IsMoving { get { return _movingLast > 0.0; } }
        public readonly double Speed;
        public readonly uint Power;
        public uint Swaps { get { return _swapRotationShift / 2; } }
        public readonly bool IsLocked = false;

        public Level(Board board, Configuration config, Position position)
        {
            Board = board;
            Config = config;
            _position = position;

            Speed = Config.Speed.Initial;
            Power = Config.Power.Initial;
        }

        public void Move(Direction direction)
        {
            if (!_directionOrder.Contains(direction))
                _directionOrder.AddFirst(direction);
        }

        public void Stop(Direction direction)
        {
            Debug.Assert(_directionOrder.Remove(direction), "Inconsistent: direction was not added");
        }

        public void TimePassed(double delta)
        {
            if (IsMoving) _movingLast -= delta;
            else if (_movingLast < 0) _movingLast = 0;
        }

        private void MatchForward()
        {
            var diceTile = (Board[_position] as MainDiceTile)!;
            switch (diceTile.Match)
            {
                case Match.NEVER:
                    Board[_position] = diceTile.WithMatch(Match.TOP);
                    break;
                case Match.TOP:
                    Board[_position] = diceTile.WithMatch(Match.ALWAYS);
                    break;
            }
        }

        private void MatchBackward()
        {
            var diceTile = (Board[_position] as MainDiceTile)!;
            switch (diceTile.Match)
            {
                case Match.TOP:
                    Board[_position] = diceTile.WithMatch(Match.NEVER);
                    break;
                case Match.ALWAYS:
                    Board[_position] = diceTile.WithMatch(Match.TOP);
                    break;
            }
        }
    }
}
