using System;
using System.Runtime.CompilerServices;
using HLE;

namespace AdventOfCode.Year2022.Day10;

public sealed class Puzzle10 : Puzzle
{
    public Puzzle10() : base("Year2022.Day10.Input.txt")
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public (int SignalSum, char[] DisplayOutput) Solve()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[145];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        byte clockCycle = 0;
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

        Span<char> pixels = stackalloc char[240];
        pixels.Fill(' ');

        for (int i = 0; i < 145; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            byte cycleCount = (byte)(line[0] == 'n' ? 1 : 2);
            Task currentTask = cycleCount == 1 ? Task.Nop : new(sbyte.Parse(line[5..]));
            while (!currentTask.Completed)
            {
                byte horizontalPixelCoordinate = GetPixelIndexFromCycle(clockCycle);
                bool drawPixel = horizontalPixelCoordinate == registerValue || horizontalPixelCoordinate == registerValue + 1 || horizontalPixelCoordinate == registerValue - 1;
                if (drawPixel)
                {
                    pixels[clockCycle] = '#';
                }

                clockCycle++;
                currentTask.Work();

                if (clockCycle <= 220 && clockCycle == cycleStack.Peek())
                {
                    signalSum += registerValue * cycleStack.Pop();
                }
            }

            registerValue += currentTask.Value;
        }

        return (signalSum, pixels.ToArray());
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private static byte GetPixelIndexFromCycle(byte clockCycle)
    {
        byte pixelIndex = clockCycle switch
        {
            < 41 => clockCycle,
            < 81 => (byte)(clockCycle - 40),
            < 121 => (byte)(clockCycle - 80),
            < 161 => (byte)(clockCycle - 120),
            < 201 => (byte)(clockCycle - 160),
            _ => (byte)(clockCycle - 200)
        };

        return (byte)(pixelIndex == 40 ? 0 : pixelIndex);
    }
}
