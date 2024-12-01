using System;
using HLE.Memory;
using HLE.Resources;

namespace AdventOfCode;

public abstract class Puzzle
{
    private protected ReadOnlySpan<byte> Input => _input;

    private readonly byte[] _input;

    private static readonly ResourceReader s_reader = new(typeof(Puzzle).Assembly);

    private protected Puzzle(string resourceName)
    {
        ReadOnlySpan<byte> resource = s_reader.Read(resourceName).AsSpan();
        using RentedArray<byte> rentedArray = ArrayPool<byte>.Shared.RentAsRentedArray(resource.Length);
        Span<byte> buffer = rentedArray.AsSpan(..resource.Length);
        SpanHelpers.Copy(resource, buffer);

        int index = buffer.IndexOf("\r\n"u8);
        while (index >= 0)
        {
            buffer[index] = (byte)'\n';
            SpanHelpers.Copy(buffer[(index + 2)..], buffer[(index + 1)..]);
            buffer = buffer[..^1];
            index = buffer.IndexOf("\r\n"u8);
        }

        if (buffer.EndsWith("\r\n"u8))
        {
            buffer = buffer[..^2];
        }
#pragma warning disable S126
        else if (buffer.EndsWith("\n"u8))
#pragma warning restore S126
        {
            buffer = buffer[..^1];
        }

        _input = buffer.ToArray();
    }
}
