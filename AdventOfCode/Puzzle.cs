using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using HLE.Memory;
using HLE.Resources;

namespace AdventOfCode;

public abstract unsafe class Puzzle : IDisposable
{
    /// <summary>
    /// Gets the normalized input data in UTF-8 for the puzzle.
    /// CRLF line endings are normalized to LF and
    /// doesn't end with a LF.
    /// </summary>
    private protected ReadOnlySpan<byte> InputUtf8 => _inputUtf8.AsSpan();

    /// <summary>
    /// Gets the normalized input data for the puzzle.
    /// CRLF line endings are normalized to LF and
    /// doesn't end with a LF.
    /// </summary>
    private protected ReadOnlySpan<char> Input => _input.AsSpan();

    private protected byte* InputUtf8Pointer => (byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(InputUtf8));

    private protected char* InputPointer => (char*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(Input));

    private readonly NativeMemory<byte> _inputUtf8;
    private readonly NativeMemory<char> _input;

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

        _inputUtf8 = new(buffer.Length, false);
        buffer.CopyTo(_inputUtf8.AsSpan());

        using RentedArray<char> chars = ArrayPool<char>.Shared.RentAsRentedArray(Encoding.UTF8.GetMaxCharCount(buffer.Length));
        int charCount = Encoding.UTF8.GetChars(buffer, chars.AsSpan());
        _input = new(charCount, false);
        chars.AsSpan(..charCount).CopyTo(_input.AsSpan());
    }

    ~Puzzle() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // ReSharper disable once UnusedParameter.Global
    protected virtual void Dispose(bool disposing)
    {
        _inputUtf8.Dispose();
        _input.Dispose();
    }
}
