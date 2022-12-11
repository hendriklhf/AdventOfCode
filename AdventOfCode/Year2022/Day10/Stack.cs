using System;

namespace AdventOfCode.Year2022.Day10;

public ref struct Stack<T>
{
    private readonly Span<T> _stack;
    private int _count = 0;

    public Stack(Span<T> stack, int count = 0)
    {
        _stack = stack;
        _count = count;
    }

    public T Pop() => _stack[--_count];

    public void Push(T item) => _stack[_count++] = item;

    public readonly T Peek() => _stack[_count - 1];
}
