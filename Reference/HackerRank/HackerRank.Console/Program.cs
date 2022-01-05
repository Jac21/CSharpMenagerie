// See https://aka.ms/new-console-template for more information
using HackerRank;
using static System.Console;

Console.WriteLine("Hello, World!");

var simpleCase = TownJudgeFinder.FindJudge(2, new int[][]
{
    new int[] {1, 2}
});

WriteLine($"Simple Case:{simpleCase}");

var largerCase = TownJudgeFinder.FindJudge(3, new int[][]
{
    new int[] {1, 3},
    new int[] {2, 3}
});

WriteLine($"Larger Case:{largerCase}");

var veryLargeCase = TownJudgeFinder.FindJudge(4, new int[][]
{
    new int[] {1, 3},
    new int[] {1, 4},
    new int[] {2, 3},
    new int[] {2, 4},
    new int[] {4, 3},
});

WriteLine($"Very Large Case:{veryLargeCase}");

var noJudgeCase = TownJudgeFinder.FindJudge(3, new int[][]
{
    new int[] {1, 3},
    new int[] {2, 3},
    new int[] {3, 1},
});

WriteLine($"No Judge Case: {noJudgeCase}");

ReadLine();