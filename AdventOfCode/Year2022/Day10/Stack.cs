using System;
using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2022.Day10;

public ref struct Stack<T>
{
    private readonly Span<T> _stack;
    private int _count = 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Stack(Span<T> stack, int count = 0)
    {
        _stack = stack;
        _count = count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Pop() => _stack[--_count];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly T Peek() => _stack[_count - 1];
}
