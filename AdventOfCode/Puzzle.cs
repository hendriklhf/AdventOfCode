using System;
using System.Reflection;
using HLE.Resources;

namespace AdventOfCode;

public abstract class Puzzle
{
    private protected readonly string _input;

    private static readonly ResourceReader _reader = new(Assembly.GetExecutingAssembly());

    private protected Puzzle(string inputResourceName)
    {
        string? input = _reader.Read(inputResourceName);
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input));
        }

        _input = input.EndsWith(Environment.NewLine, StringComparison.InvariantCulture) ? input[..^Environment.NewLine.Length] : input;
    }
}
