using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using HLE.Memory;
using HLE.Resources;

namespace AdventOfCode;

public abstract unsafe class Puzzle
{
    /// <summary>
    /// Gets the normalized input data in UTF-8 for the puzzle.
    /// CRLF line endings are normalized to LF and
    /// doesn't end with a LF.
    /// </summary>
    private protected ReadOnlySpan<byte> InputUtf8 => _inputUtf8;

    /// <summary>
    /// Gets the normalized input data for the puzzle.
    /// CRLF line endings are normalized to LF and
    /// doesn't end with a LF.
    /// </summary>
    private protected ReadOnlySpan<char> Input => _input;

    private protected byte* InputUtf8Pointer => (byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(InputUtf8));

    private readonly byte[] _inputUtf8;
    private readonly string _input;

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

        _inputUtf8 = buffer.ToArray();
        _input = Encoding.UTF8.GetString(_inputUtf8);
    }
}
