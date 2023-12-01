using System;
using HLE.Resources;

namespace AdventOfCode;

public abstract class Puzzle
{
    private protected readonly Resource _input;

    private static readonly ResourceReader s_reader = new(typeof(Puzzle).Assembly);

    private protected Puzzle(string resourceName)
    {
        if (!s_reader.TryRead(resourceName, out Resource resource))
        {
            throw new InvalidOperationException($"Resource {resourceName} not found.");
        }

        _input = resource;
    }
}
