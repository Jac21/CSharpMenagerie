using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Tree.He
{
    /*
     * Problem
    Given an array A of N integers, classify it as being Good Bad or Average. It is called Good, if it contains exactly X distinct integers, Bad if it contains less than X distinct integers and Average if it contains more than X distinct integers.

    Input format:
    First line consists of a single integer T denoting the number of test cases.
    First line of each test case consists of two space separated integers denoting N and X.
    Second line of each test case consists of N space separated integers denoting the array elements.

    Output format:
    Print the required answer for each test case on a new line.

    Constraints:



    Sample Input
    4
    4 1
    1 4 2 5
    4 2
    4 2 1 5
    4 3
    5 2 4 1
    4 4
    1 2 4 5
    Sample Output
    Average
    Average
    Average
    Good
     */
    public class DistinctCount
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var inputLine = Console.ReadLine()
                    .Split();

                var n = Convert.ToInt32(inputLine.FirstOrDefault());
                var x = Convert.ToInt32(inputLine.Skip(1).FirstOrDefault());

                var arrayLineSplit = Console.ReadLine().Split();

                PrintDistinctCountResult(n, x, arrayLineSplit);
            }
        }

        private static void PrintDistinctCountResult(int n, int x, string[] arrayLineSplit)
        {
            var distinct = new HashSet<int>();

            for (var i = 0; i < n; i++)
            {
                distinct.Add(Convert.ToInt32(arrayLineSplit[i]));
            }

            var count = distinct.Count;

            if (count == x)
            {
                Console.WriteLine("Good");
            }
            else if (count < x)
            {
                Console.WriteLine("Bad");
            }
            else if (count > x)
            {
                Console.WriteLine("Average");
            }
        }
    }
}