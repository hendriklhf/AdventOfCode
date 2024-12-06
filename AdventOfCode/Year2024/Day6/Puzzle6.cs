using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2024.Day6;

public sealed unsafe class Puzzle6 : Puzzle
{
    private readonly uint _lineLength;
    private readonly uint _lineCount;
    private readonly HashSet<(int, int)> _visited;

    public Puzzle6() : base("AdventOfCode.Year2024.Day6.input.txt")
    {
        ReadOnlySpan<byte> input = InputUtf8;
        _lineLength = (uint)input.IndexOf((byte)'\n');
        _lineCount = (uint)(input.Count((byte)'\n')) + 1;
        _visited = new((int)(_lineCount * _lineLength));
    }

    [SkipLocalsInit]
    public uint SolvePartOne()
    {
        (int X, int Y)* directionChanges = stackalloc (int, int)[4]
        {
            (0, -1),
            (1, 0),
            (0, 1),
            (-1, 0)
        };

        ReadOnlySpan<byte> input = InputUtf8;
        byte* inputPtr = InputUtf8Pointer;
        int startIndex = input.IndexOf((byte)'^');
        (int X, int Y) position = ConvertIndexToCoordinates(startIndex);
        _visited.Add(position);
        uint direction = 0;

        while (true)
        {
            (int xChanges, int yChanges) = directionChanges[direction];
            (int X, int Y) newPosition = (position.X + xChanges, position.Y + yChanges);
            if (newPosition.X < 0 || newPosition.X >= _lineLength || newPosition.Y < 0 || newPosition.Y >= _lineCount)
            {
                return (uint)_visited.Count;
            }

            int newPositionIndex = ConvertCoordinatesToIndex(newPosition.X, newPosition.Y);
            if (inputPtr[newPositionIndex] == '#')
            {
                direction = (direction + 1) % 4;
                continue;
            }

            position = newPosition;
            _visited.Add(position);
        }
    }

    private (int X, int Y) ConvertIndexToCoordinates(int index)
    {
        (uint y, uint x) = Math.DivRem((uint)index, _lineLength + 1);
        return ((int)x, (int)y);
    }

    private int ConvertCoordinatesToIndex(int x, int y) => (int)((uint)y * _lineLength + (uint)y + (uint)x);
}
