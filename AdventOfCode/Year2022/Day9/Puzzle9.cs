using System;
using HLE;

namespace AdventOfCode.Year2022.Day9;

public sealed class Puzzle9 : Puzzle
{
    public Puzzle9() : base("Year2022.Day9.Input.txt")
    {
    }

    public unsafe int Solve()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[2000];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        (int X, int Y) head = (0, 0);
        (int X, int Y) tail = (0, 0);
        Span<(int, int)> visitedCoordinates = stackalloc (int, int)[10000];
        visitedCoordinates[0] = tail;
        int visitedCount = 1;
        for (int i = 0; i < 2000; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            char direction = line[0];
            byte count = byte.Parse(line[2..]);

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

                if (!visitedCoordinates[..visitedCount].Contains(tail))
                {
                    visitedCoordinates[visitedCount++] = tail;
                }
            }
        }

        Console.WriteLine(head);
        Console.WriteLine(tail);
        return visitedCount;
    }
}
