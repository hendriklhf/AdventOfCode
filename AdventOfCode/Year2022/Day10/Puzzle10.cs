using System;
using HLE;

namespace AdventOfCode.Year2022.Day10;

public sealed class Puzzle10 : Puzzle
{
    public Puzzle10() : base("Year2022.Day10.Input.txt")
    {
    }

    public (int, char[]) Solve()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[145];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        ushort clockCycle = 0;
        short registerValue = 1;
        int signalSum = 0;

        Span<byte> cyclesToCheck = stackalloc byte[]
        {
            220,
            180,
            140,
            100,
            60,
            20
        };
        Stack<byte> cycleStack = new(cyclesToCheck, cyclesToCheck.Length);

        Span<char> pixels = stackalloc char[241];
        pixels.Fill(' ');
        for (int i = 0; clockCycle < 240; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            byte cycleCount = (byte)(line[0] == 'n' ? 1 : 2);
            sbyte value = cycleCount > 1 && sbyte.TryParse(line[5..], out value) ? value : (sbyte)0;
            clockCycle += cycleCount;

            if (clockCycle < 221 && clockCycle >= cycleStack.Peek())
            {
                signalSum += registerValue * cycleStack.Pop();
                registerValue += value;
            }
            else
            {
                registerValue += value;
            }
        }

        return (signalSum, pixels[1..].ToArray());
    }
}
