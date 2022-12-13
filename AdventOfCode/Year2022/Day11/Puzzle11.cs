using System;
using System.Diagnostics.CodeAnalysis;
using HLE;

namespace AdventOfCode.Year2022.Day11;

[SuppressMessage("Reliability", "CA2014:Do not use stackalloc in loops")]
[SuppressMessage("ReSharper", "StackAllocInsideLoop")]
public sealed class Puzzle11 : Puzzle
{
    public Puzzle11() : base("Year2022.Day11.Input.txt")
    {
    }

    public unsafe ulong SolvePart1()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[55];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        Span<Monkey> monkeys = stackalloc Monkey[8];
        for (int i = 1, m = 0; i < 55; i += 2)
        {
            ReadOnlySpan<char> itemsLine = input[lineRanges[i++]][18..];
            ReadOnlySpan<char> operationLine = input[lineRanges[i++]][23..];
            ReadOnlySpan<char> testLine = input[lineRanges[i++]][21..];
            ReadOnlySpan<char> trueLine = input[lineRanges[i++]][28..];
            ReadOnlySpan<char> falseLine = input[lineRanges[i++]][29..];

            Span<ulong> items = stackalloc ulong[30];
            byte itemCount = 0;
            while (true)
            {
                items[itemCount++] = byte.Parse(itemsLine[..2]);
                if (itemsLine.Length == 2)
                {
                    break;
                }

                itemsLine = itemsLine[4..];
            }

            char operation = operationLine[0];
            byte operationValue = operationLine[2] == 'o' ? (byte)0 : byte.Parse(operationLine[2..]);
            byte divideBy = byte.Parse(testLine);
            byte testTrue = byte.Parse(trueLine);
            byte testFalse = byte.Parse(falseLine);

            monkeys[m++] = new(items, itemCount, operation, operationValue, divideBy, testTrue, testFalse);
        }

        for (int round = 0; round < 20; round++)
        {
            for (int m = 0; m < 8; m++)
            {
                ref Monkey monkey = ref monkeys[m];
                ulong* items = monkey.Items;
                for (int i = 0; i < monkey.ItemCount; i++)
                {
                    ulong item = items[i];
                    ulong newValue = monkey.Inspect(item) / 3;
                    byte target = monkey.GetThrowTarget(newValue);
                    ref Monkey targetMonkey = ref monkeys[target];
                    targetMonkey.Items[targetMonkey.ItemCount++] = newValue;
                }

                monkey.ItemCount = 0;
            }
        }

        Span<ulong> topTwo = stackalloc ulong[]
        {
            monkeys[0].InspectCount,
            monkeys[1].InspectCount
        };
        int minIdx = topTwo[0] > topTwo[1] ? 1 : 0;
        for (int i = 2; i < 8; i++)
        {
            if (monkeys[i].InspectCount > topTwo[minIdx])
            {
                topTwo[minIdx] = monkeys[i].InspectCount;
            }

            minIdx = topTwo[0] > topTwo[1] ? 1 : 0;
        }

        return topTwo[0] * topTwo[1];
    }

    public unsafe ulong SolvePart2()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[55];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        Span<Monkey> monkeys = stackalloc Monkey[8];
        uint commonDivisor = 1;
        for (int i = 1, m = 0; i < 55; i += 2)
        {
            ReadOnlySpan<char> itemsLine = input[lineRanges[i++]][18..];
            ReadOnlySpan<char> operationLine = input[lineRanges[i++]][23..];
            ReadOnlySpan<char> testLine = input[lineRanges[i++]][21..];
            ReadOnlySpan<char> trueLine = input[lineRanges[i++]][28..];
            ReadOnlySpan<char> falseLine = input[lineRanges[i++]][29..];

            Span<ulong> items = stackalloc ulong[30];
            byte itemCount = 0;
            while (true)
            {
                items[itemCount++] = byte.Parse(itemsLine[..2]);
                if (itemsLine.Length == 2)
                {
                    break;
                }

                itemsLine = itemsLine[4..];
            }

            char operation = operationLine[0];
            byte operationValue = operationLine[2] == 'o' ? (byte)0 : byte.Parse(operationLine[2..]);
            byte divideBy = byte.Parse(testLine);
            commonDivisor *= divideBy;
            byte testTrue = byte.Parse(trueLine);
            byte testFalse = byte.Parse(falseLine);

            monkeys[m++] = new(items, itemCount, operation, operationValue, divideBy, testTrue, testFalse);
        }

        for (int round = 0; round < 10000; round++)
        {
            for (int m = 0; m < 8; m++)
            {
                ref Monkey monkey = ref monkeys[m];
                ulong* items = monkey.Items;
                for (int i = 0; i < monkey.ItemCount; i++)
                {
                    ulong item = items[i];
                    ulong newValue = monkey.Inspect(item);
                    newValue %= commonDivisor;
                    byte target = monkey.GetThrowTarget(newValue);
                    ref Monkey targetMonkey = ref monkeys[target];
                    targetMonkey.Items[targetMonkey.ItemCount++] = newValue;
                }

                monkey.ItemCount = 0;
            }
        }

        Span<ulong> topTwo = stackalloc ulong[]
        {
            monkeys[0].InspectCount,
            monkeys[1].InspectCount
        };
        int minIdx = topTwo[0] > topTwo[1] ? 1 : 0;
        for (int i = 2; i < 8; i++)
        {
            if (monkeys[i].InspectCount > topTwo[minIdx])
            {
                topTwo[minIdx] = monkeys[i].InspectCount;
            }

            minIdx = topTwo[0] > topTwo[1] ? 1 : 0;
        }

        return topTwo[0] * topTwo[1];
    }
}
