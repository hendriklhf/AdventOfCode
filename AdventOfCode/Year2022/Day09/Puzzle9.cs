using System;
using System.Runtime.CompilerServices;
using HLE;

#pragma warning disable CS9085

namespace AdventOfCode.Year2022.Day09;

public sealed class Puzzle9 : Puzzle
{
    public Puzzle9() : base("Year2022.Day09.Input.txt")
    {
    }

    public unsafe int SolvePart1()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[2000];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        (int X, int Y) head = (0, 0);
        (int X, int Y) tail = (0, 0);
        Span<int> visitedCoordinateHashes = stackalloc int[10000];
        visitedCoordinateHashes[0] = tail.GetHashCode();
        int visitedCount = 1;
        for (int i = 0; i < 2000; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            char direction = line[0];
            byte count = NumberHelper.ParseByte(line[2..]);

            int* headCoordinate = null;
            int movement = 0;
            switch (direction)
            {
                case 'L':
                    headCoordinate = &head.X;
                    movement = -1;
                    break;
                case 'R':
                    headCoordinate = &head.X;
                    movement = 1;
                    break;
                case 'U':
                    headCoordinate = &head.Y;
                    movement = 1;
                    break;
                case 'D':
                    headCoordinate = &head.Y;
                    movement = -1;
                    break;
            }

            for (int j = 0; j < count; j++)
            {
                *headCoordinate += movement;
                int deltaX = head.X - tail.X;
                int deltaY = head.Y - tail.Y;
                if (Math.Abs(deltaX) > 1 || Math.Abs(deltaY) > 1)
                {
                    if (deltaX == 0)
                    {
                        tail.Y += deltaY > 0 ? 1 : -1;
                    }
                    else if (deltaY == 0)
                    {
                        tail.X += deltaX > 0 ? 1 : -1;
                    }
                    else
                    {
                        tail.X += deltaX > 0 ? 1 : -1;
                        tail.Y += deltaY > 0 ? 1 : -1;
                    }
                }

                int tailHashCode = tail.GetHashCode();
                if (!visitedCoordinateHashes[..visitedCount].Contains(tailHashCode))
                {
                    visitedCoordinateHashes[visitedCount++] = tailHashCode;
                }
            }
        }

        return visitedCount;
    }

    public unsafe int SolvePart2()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[2000];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        Span<(int X, int Y)> rope = stackalloc (int, int)[10];
        Span<int> visitedCoordinateHashes = stackalloc int[10000];
        visitedCoordinateHashes[0] = rope[9].GetHashCode();
        int visitedCount = 1;
        for (int i = 0; i < 2000; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            char direction = line[0];
            byte count = NumberHelper.ParseByte(line[2..]);

            ref int headCoordinate = ref Unsafe.NullRef<int>();
            int movement = 0;
            switch (direction)
            {
                case 'L':
                    headCoordinate = ref rope[0].X;
                    movement = -1;
                    break;
                case 'R':
                    headCoordinate = ref rope[0].X;
                    movement = 1;
                    break;
                case 'U':
                    headCoordinate = ref rope[0].Y;
                    movement = 1;
                    break;
                case 'D':
                    headCoordinate = ref rope[0].Y;
                    movement = -1;
                    break;
            }

            for (int j = 0; j < count; j++)
            {
                headCoordinate += movement;

                for (int k = 0; k < 9; k++)
                {
                    ref (int X, int Y) head = ref rope[k];
                    ref (int X, int Y) tail = ref rope[k + 1];
                    int deltaX = head.X - tail.X;
                    int deltaY = head.Y - tail.Y;
                    if (Math.Abs(deltaX) <= 1 && Math.Abs(deltaY) <= 1)
                    {
                        continue;
                    }

                    if (deltaX == 0)
                    {
                        tail.Y += deltaY > 0 ? 1 : -1;
                    }
                    else if (deltaY == 0)
                    {
                        tail.X += deltaX > 0 ? 1 : -1;
                    }
                    else
                    {
                        tail.X += deltaX > 0 ? 1 : -1;
                        tail.Y += deltaY > 0 ? 1 : -1;
                    }
                }

                (int X, int Y) lastKnot = rope[9];
                int lastKnotHash = lastKnot.GetHashCode();
                if (!visitedCoordinateHashes[..visitedCount].Contains(lastKnotHash))
                {
                    visitedCoordinateHashes[visitedCount++] = lastKnotHash;
                }
            }
        }

        return visitedCount;
    }
}
