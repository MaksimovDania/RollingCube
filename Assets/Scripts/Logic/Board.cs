#nullable enable

using System;
using System.Diagnostics;

namespace Logic
{
    public class Board
    {
        public readonly uint Width;
        public readonly uint Height;
        public readonly uint Depth;
        public uint Length { get { return Width * Height * Depth; } }

        private Tile[] _tiles;

        public Board(uint width, uint height, uint depth, Tile[] tiles)
        {
            Debug.Assert(tiles.Length == width * height * depth);
            Width = width;
            Height = height;
            Depth = depth;
            this._tiles = tiles;
        }

        public Tile this[Position position]
        {
            get
            {
                Debug.Assert(WithinBounds(position));
                return _tiles[Index(position)];
            }
            set
            {
                Debug.Assert(WithinBounds(position));
                _tiles[Index(position)] = value;
            }
        }

        public uint Index(Position position)
        {
            Debug.Assert(WithinBounds(position));
            return (uint)(position.Y * Width * Depth + position.X * Depth + position.Z);
        }

        public Position Position(uint index)
        {
            Debug.Assert(index < Length);
            uint layer = Width * Depth;
            return new Position(
                (int)((index % layer) / Depth),
                (int)(index / layer),
                (int)(index % Depth)
            );
        }

        public bool WithinBounds(Position position)
        {
            return position.X >= 0 && position.Y >= 0 && position.Z >= 0 &&
                position.X < Width && position.Y < Height && position.Z < Depth;
        }

        public bool WithinBounds(uint index)
        {
            return index < Length;
        }

        public Tile? Find(Predicate<Tile> predicate)
        {
            return System.Array.Find(_tiles, predicate);
        }

        public Position? FindPosition(Predicate<Tile> predicate)
        {
            int index = System.Array.FindIndex(_tiles, predicate);
            if (index == -1)
                return null;
            else
                return this.Position((uint)index);
        }
    }
}
