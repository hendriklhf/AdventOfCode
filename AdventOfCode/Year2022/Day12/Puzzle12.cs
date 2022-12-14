using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HLE;

namespace AdventOfCode.Year2022.Day12;

public sealed class Puzzle12 : Puzzle
{
    private const byte _mapWidth = 173;
    private const byte _mapHeight = 41;
    private const ushort _nodeCount = _mapWidth * _mapHeight;

    public Puzzle12() : base("Year2022.Day12.Input.txt")
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public unsafe ushort SolvePart1()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> ranges = stackalloc Range[_mapHeight];
        input.GetRangesOfSplit(Environment.NewLine, ranges);

        Node start = default;
        Node end = default;
        Span<Node> nodes = stackalloc Node[_nodeCount];
        Node* nodesPtr = (Node*)Unsafe.AsPointer(ref nodes[0]);
        for (int i = 0, n = 0; i < _mapHeight; i++)
        {
            ReadOnlySpan<char> line = input[ranges[i]];
            for (int j = 0; j < _mapWidth; j++)
            {
                byte x = (byte)j;
                byte y = (byte)i;
                char heightChar = line[j];
                switch (heightChar)
                {
                    case 'S':
                        start = new(x, y, 0);
                        nodes[n++] = start;
                        break;
                    case 'E':
                        end = new(x, y, 25);
                        nodes[n++] = end;
                        break;
                    default:
                        nodes[n++] = new(x, y, (byte)(heightChar - 'a'));
                        break;
                }
            }
        }

        Queue<nuint> queue = new();
        Node* startPtr = &start;
        queue.Enqueue((nuint)startPtr);
        Span<nuint> neighbours = stackalloc nuint[4];
        while (queue.TryDequeue(out nuint nodePtr))
        {
            byte neighbourCount = 0;
            Node* node = (Node*)nodePtr;
            byte nodeYPlus1 = (byte)(node->Y + 1);
            if (nodeYPlus1 < _mapHeight)
            {
                neighbours[neighbourCount++] = (nuint)GetNode(nodesPtr, node->X, nodeYPlus1);
            }

            int nodeYMinus1 = node->Y - 1;
            if (nodeYMinus1 >= 0)
            {
                neighbours[neighbourCount++] = (nuint)GetNode(nodesPtr, node->X, (byte)nodeYMinus1);
            }

            byte nodeXPlus1 = (byte)(node->X + 1);
            if (nodeXPlus1 < _mapWidth)
            {
                neighbours[neighbourCount++] = (nuint)GetNode(nodesPtr, nodeXPlus1, node->Y);
            }

            int nodeXMinus1 = node->X - 1;
            if (nodeXMinus1 >= 0)
            {
                neighbours[neighbourCount++] = (nuint)GetNode(nodesPtr, (byte)nodeXMinus1, node->Y);
            }

            for (byte i = 0; i < neighbourCount; i++)
            {
                Node* neighbour = (Node*)neighbours[i];
                if (neighbour->Visited)
                {
                    continue;
                }

                if (!node->CanVisit(neighbour->Height))
                {
                    continue;
                }

                if (neighbour->X == end.X && neighbour->Y == end.Y)
                {
                    return ++node->Distance;
                }

                neighbour->Visited = true;
                neighbour->Distance = (ushort)(node->Distance + 1);
                queue.Enqueue((nuint)neighbour);
            }
        }

        throw new InvalidOperationException("No path found!");
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public unsafe ushort SolvePart2()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> ranges = stackalloc Range[_mapHeight];
        input.GetRangesOfSplit(Environment.NewLine, ranges);

        Node end = default;
        Span<Node> nodes = stackalloc Node[_nodeCount];
        Node* nodesPtr = (Node*)Unsafe.AsPointer(ref nodes[0]);
        for (int i = 0, n = 0; i < _mapHeight; i++)
        {
            ReadOnlySpan<char> line = input[ranges[i]];
            for (int j = 0; j < _mapWidth; j++)
            {
                byte x = (byte)j;
                byte y = (byte)i;
                char heightChar = line[j];
                switch (heightChar)
                {
                    case 'S':
                        nodes[n++] = new(x, y, 0);
                        break;
                    case 'E':
                        end = new(x, y, 25);
                        nodes[n++] = end;
                        break;
                    default:
                        nodes[n++] = new(x, y, (byte)(heightChar - 'a'));
                        break;
                }
            }
        }

        Queue<nuint> queue = new();
        Node* endPtr = &end;
        queue.Enqueue((nuint)endPtr);
        Span<nuint> neighbours = stackalloc nuint[4];
        while (queue.TryDequeue(out nuint nodePtr))
        {
            byte neighbourCount = 0;
            Node* node = (Node*)nodePtr;
            byte nodeYPlus1 = (byte)(node->Y + 1);
            if (nodeYPlus1 < _mapHeight)
            {
                neighbours[neighbourCount++] = (nuint)GetNode(nodesPtr, node->X, nodeYPlus1);
            }

            int nodeYMinus1 = node->Y - 1;
            if (nodeYMinus1 >= 0)
            {
                neighbours[neighbourCount++] = (nuint)GetNode(nodesPtr, node->X, (byte)nodeYMinus1);
            }

            byte nodeXPlus1 = (byte)(node->X + 1);
            if (nodeXPlus1 < _mapWidth)
            {
                neighbours[neighbourCount++] = (nuint)GetNode(nodesPtr, nodeXPlus1, node->Y);
            }

            int nodeXMinus1 = node->X - 1;
            if (nodeXMinus1 >= 0)
            {
                neighbours[neighbourCount++] = (nuint)GetNode(nodesPtr, (byte)nodeXMinus1, node->Y);
            }

            for (byte i = 0; i < neighbourCount; i++)
            {
                Node* neighbour = (Node*)neighbours[i];
                if (neighbour->Visited)
                {
                    continue;
                }

                if (!neighbour->CanVisit(node->Height))
                {
                    continue;
                }

                if (neighbour->X == 0)
                {
                    return ++node->Distance;
                }

                neighbour->Visited = true;
                neighbour->Distance = (ushort)(node->Distance + 1);
                queue.Enqueue((nuint)neighbour);
            }
        }

        throw new InvalidOperationException("No path found!");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe Node* GetNode(Node* nodes, byte x, byte y)
    {
        return nodes + (y * _mapWidth + x);
    }
}
