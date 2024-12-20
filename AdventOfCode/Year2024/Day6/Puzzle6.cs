using System;

namespace AdventOfCode.Year2024.Day6;

public sealed unsafe class Puzzle6 : Puzzle
{
    private readonly uint _lineLength;
    private readonly uint _lineCount;

    public Puzzle6() : base("AdventOfCode.Year2024.Day6.input.txt")
    {
        ReadOnlySpan<byte> input = InputUtf8;
        _lineLength = (uint)input.IndexOf((byte)'\n');
        _lineCount = (uint)(input.Count((byte)'\n')) + 1;
    }

    public uint SolvePartOne()
    {
        (int X, int Y)* directionChanges = stackalloc (int, int)[4]
        {
            (0, -1),
            (1, 0),
            (0, 1),
            (-1, 0)
        };

        bool* visitMap = stackalloc bool[(int)(_lineLength * _lineCount)];
        byte* inputPtr = InputUtf8Pointer;
        int startIndex = InputUtf8.IndexOf((byte)'^');
        (int X, int Y) position = ConvertIndexToCoordinates(startIndex);
        visitMap[startIndex] = true;
        uint result = 1;
        uint direction = 0;

        while (true)
        {
            (int xChanges, int yChanges) = directionChanges[direction];
            (int X, int Y) newPosition = (position.X + xChanges, position.Y + yChanges);
            if (newPosition.X < 0 || newPosition.X >= _lineLength || newPosition.Y < 0 || newPosition.Y >= _lineCount)
            {
                return result;
            }

            int newPositionIndex = ConvertCoordinatesToIndex(newPosition.X, newPosition.Y);
            if (inputPtr[newPositionIndex] == '#')
            {
                direction = (direction + 1) % 4;
                continue;
            }

            position = newPosition;
            int index = ConvertCoordinatesToIndex(position.X, position.Y);
            bool* visited = visitMap + index;
            if (!*visited)
            {
                *visited = true;
                result++;
            }
        }
    }

    private (int X, int Y) ConvertIndexToCoordinates(int index)
    {
        (uint y, uint x) = Math.DivRem((uint)index, _lineLength + 1);
        return ((int)x, (int)y);
    }

    private int ConvertCoordinatesToIndex(int x, int y) => (int)((uint)y * _lineLength + (uint)y + (uint)x);
}
