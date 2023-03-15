using System;
using HLE;

namespace AdventOfCode.Year2022.Day05;

public sealed class Puzzle5 : Puzzle
{
    private const byte _stackSize = 50;

    public Puzzle5() : base("Year2022.Day05.Input.txt")
    {
    }

    public unsafe string SolvePart1()
    {
        byte* stack1 = stackalloc byte[_stackSize];
        byte* stack2 = stackalloc byte[_stackSize];
        byte* stack3 = stackalloc byte[_stackSize];
        byte* stack4 = stackalloc byte[_stackSize];
        byte* stack5 = stackalloc byte[_stackSize];
        byte* stack6 = stackalloc byte[_stackSize];
        byte* stack7 = stackalloc byte[_stackSize];
        byte* stack8 = stackalloc byte[_stackSize];
        byte* stack9 = stackalloc byte[_stackSize];
        Stack* stacks = stackalloc Stack[]
        {
            new(stack1, 4),
            new(stack2, 8),
            new(stack3, 3),
            new(stack4, 6),
            new(stack5, 8),
            new(stack6, 7),
            new(stack7, 5),
            new(stack8, 8),
            new(stack9, 7)
        };

        ParseStacks(stacks);

        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[512];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        Span<Range> ranges = stackalloc Range[6];
        for (int i = 10; i < 512; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            line.GetRangesOfSplit(' ', ranges);
            byte count = NumberHelper.ParseByte(line[ranges[1]]);
            byte source = (byte)(NumberHelper.ParseByte(line[ranges[3]]) - 1);
            byte destination = (byte)(NumberHelper.ParseByte(line[ranges[5]]) - 1);

            for (int j = 0; j < count; j++)
            {
                byte item = stacks[source].Pop();
                stacks[destination].Push(item);
            }
        }

        Span<char> chars = stackalloc char[9];
        for (int i = 0; i < 9; i++)
        {
            chars[i] = (char)stacks[i].Peek();
        }

        return new(chars);
    }

    public unsafe string SolvePart2()
    {
        byte* stack1 = stackalloc byte[_stackSize];
        byte* stack2 = stackalloc byte[_stackSize];
        byte* stack3 = stackalloc byte[_stackSize];
        byte* stack4 = stackalloc byte[_stackSize];
        byte* stack5 = stackalloc byte[_stackSize];
        byte* stack6 = stackalloc byte[_stackSize];
        byte* stack7 = stackalloc byte[_stackSize];
        byte* stack8 = stackalloc byte[_stackSize];
        byte* stack9 = stackalloc byte[_stackSize];
        Stack* stacks = stackalloc Stack[]
        {
            new(stack1, 4),
            new(stack2, 8),
            new(stack3, 3),
            new(stack4, 6),
            new(stack5, 8),
            new(stack6, 7),
            new(stack7, 5),
            new(stack8, 8),
            new(stack9, 7)
        };

        ParseStacks(stacks);

        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[512];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        Span<Range> ranges = stackalloc Range[6];
        byte* stackBuffer = stackalloc byte[_stackSize];
        for (int i = 10; i < 512; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            line.GetRangesOfSplit(' ', ranges);
            byte count = NumberHelper.ParseByte(line[ranges[1]]);
            byte source = (byte)(NumberHelper.ParseByte(line[ranges[3]]) - 1);
            byte destination = (byte)(NumberHelper.ParseByte(line[ranges[5]]) - 1);

            Stack stack = new(stackBuffer);
            for (int j = 0; j < count; j++)
            {
                byte item = stacks[source].Pop();
                stack.Push(item);
            }

            for (int j = 0; j < count; j++)
            {
                byte item = stack.Pop();
                stacks[destination].Push(item);
            }
        }

        Span<char> chars = stackalloc char[9];
        for (int i = 0; i < 9; i++)
        {
            chars[i] = (char)stacks[i].Peek();
        }

        return new(chars);
    }

    private unsafe void ParseStacks(Stack* stacks)
    {
        ReadOnlySpan<char> input = _input;
        ReadOnlySpan<char> crateStackArea = input[..340];
        Span<Range> ranges = stackalloc Range[10];
        crateStackArea.GetRangesOfSplit(Environment.NewLine, ranges);
        for (int i = 7; i >= 0; i--)
        {
            ReadOnlySpan<char> line = crateStackArea[ranges[i]];
            for (int j = 1, k = 0; j < 34; j += 4, k++)
            {
                char item = line[j];
                if (item != ' ')
                {
                    stacks[k].Push((byte)item);
                }
            }
        }
    }
}
