using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AdventOfCode.Year2024.Day7;

public sealed partial class Puzzle7
{
    private sealed unsafe class State(ref uint numbers, ReadOnlySpan<byte> input)
    {
        public uint* Numbers { get; } = (uint*)Unsafe.AsPointer(ref numbers);

        public ReadOnlySpan<byte> Input => new(_input, _inputLength);

        private readonly byte* _input = (byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(input));
        private readonly int _inputLength = input.Length;
    }
}
