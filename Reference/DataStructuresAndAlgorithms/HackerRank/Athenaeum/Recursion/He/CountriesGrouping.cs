using System;
using System.Linq;

namespace Athenaeum.Recursion.He
{
    /*
     * Countries Grouping
87% Success
6840 Attempts
20 Points
1s Time Limit
256MB Memory
1024 KB Max Code
People in the group, are sitting in a row numbered from 1 to N. Every person have been asked with a same question as

How many people of your country are there in the group?

The answers provided may be incorrect. It is known that people of same countries always sit together.

If all the given answers are correct, determine the number of distinct countries present otherwise print "Invalid Data".

Input

First line contains one integer, which denotes the number of test cases

Each test case consists of 2 lines:

The first line contains one integer N, which denotes the total number of people there in the group.

The second line contains N space-separated integers say 
 , which denotes the answer given by the 
 person.

Output

For each test case output a single line containing a single integer denoting the distinct countries or "Invalid Data".

Constraints:




Examples
Input

4
2
1 1
2
1 3
7
1 1 2 2 3 3 3
7
7 7 7 7 7 7 7
Output

2
Invalid Data
4
1
Explanation
First test case, there are two people each from different country.

Second test case, there are only two people but the the second person claims as there are three people of his country.
     */
    public class CountriesGrouping
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var n = Convert.ToInt32(Console.ReadLine());

                var a = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var result = Solve(0, n, a);

                var output = result != -1 ? result.ToString() : "Invalid Data";

                Console.WriteLine(output);
            }
        }

        private static int Solve(int index, int n, int[] a)
        {
            if (index == n) return 0;

            // claimed group size
            var k = a[index];

            // validations
            // not enough people left
            if (index + k > n) return -1;

            // consistency checks
            for (var j = index; j < index + k; j++)
            {
                if (a[j] != k) return -1;
            }

            var result = Solve(index + k, n, a);

            if (result == -1) return -1;

            return 1 + result;
        }
    }
}