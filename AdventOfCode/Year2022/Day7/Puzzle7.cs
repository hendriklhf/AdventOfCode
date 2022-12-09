using System;
using System.Diagnostics.CodeAnalysis;
using HLE;

// ReSharper disable StackAllocInsideLoop

namespace AdventOfCode.Year2022.Day7;

[SuppressMessage("Reliability", "CA2014:Do not use stackalloc in loops")]
public sealed class Puzzle7 : Puzzle
{
    private const string _changedDirectory = "$ cd ";
    private const string _directory = "dir ";
    private const string _chanedDirectoryUp = "$ cd ..";
    private const ulong _maxDirectorySize = 100000;

    public Puzzle7() : base("Year2022.Day7.Input.txt")
    {
    }

    public unsafe ulong SolvePart1()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[964];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        Directory startDirectory = new(new(input[5]), stackalloc Directory[10], null);
        Directory* currentDirectory = &startDirectory;
        for (int i = 2; i < 964; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            if (line.Equals(_chanedDirectoryUp, StringComparison.Ordinal))
            {
                currentDirectory = currentDirectory->Parent;
            }
            else if (line.StartsWith(_directory))
            {
                Directory child = new(line[_directory.Length..], stackalloc Directory[10], currentDirectory);
                currentDirectory->AddChildDirectory(&child);
            }
            else if (line.StartsWith(_changedDirectory))
            {
                Directory* nextDirectory = currentDirectory->GetChildDirectoryByName(line[_changedDirectory.Length..]);
                currentDirectory = nextDirectory;
            }
            else if (char.IsDigit(line[0]))
            {
                Span<Range> ranges = stackalloc Range[2];
                line.GetRangesOfSplit(' ', ranges);
                ulong size = ulong.Parse(line[ranges[0]]);
                currentDirectory->Size += size;
            }
        }

        ulong result = 0;
        GetResultCount(&startDirectory, &result);
        return result;
    }

    private static unsafe void GetResultCount(Directory* directory, ulong* result)
    {
        for (int i = 0; i < directory->ChildCount; i++)
        {
            Directory* child = &directory->ChildDirectories[i];
            ulong size = child->TotalSize;
            if (size <= _maxDirectorySize)
            {
                *result += size;
            }

            GetResultCount(child, result);
        }
    }
}
