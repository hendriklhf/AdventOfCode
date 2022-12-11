using AdventOfCode.Year2022.Day10;
using HLE;

(int signalStrength, char[] pixels) = new Puzzle10().Solve();
Console.WriteLine(signalStrength);
var part = new string(pixels).Part(40);
for (int i = 0; i < part.Length; i++)
{
    Console.WriteLine(part[i]);
}
