using System;
using System.Linq;

namespace Athenaeum.Greedy.He
{
    /*
     * In the realm of StarRail, a grand interstellar train known for its luxurious compartments, each carriage comes with a unique seating arrangement denoted by an array 
. The array 
 represents the number of seats in each compartment, adding to the train's charm and comfort.

A brilliant engineer named Nova has been entrusted with the task of enhancing the seating capacity of the StarRail.

Nova possesses a unique ability: he can perform the following operation atmost once. This operation enables Nova to select two compartments, denoted by indices 
 and 
, and modify the number of seats in all compartments between 
 and 
 (inclusive) by performing a bitwise 
 operation with value 
, where 
.

Mathematically, the operation can be expressed as follows: 
 (
 denotes the bitwise the 
 operation), where 
.

Nova's ultimate objective is to maximize the overall seating capacity of StarRail using this operation.

Help Nova determine the maximum number of passengers that can travel on the StarRail by finding the optimal compartments to perform the operation on and maximizing the total seating capacity.

Input Format:

The first line of input data contains single integer 
 — the number of test cases in the test.

For each testcase the first line contains two integers 
 - the number of compartment in StarRail and 
 - the number given to Nova.

The second line contains 
 integers 
 – the number of seats in each compartment.

Note: Sum of all 
 doesn’t exceed 

Output Format:

For each testcase output a single integer - the maximum number of passengers that can travel on the StarRail.

Constraints:

Examples
Input

1
5 5
5 2 2 2 5
Output

31
Explanation
We have for n = 5, y = 5
S[] = {5 2 2 2 5}

We get maximum sum by selecting compartments 2 and 4,

S[] = {5, 2⊕5, 2⊕5, 2⊕5, 5} = {5,7,7,7,5}

after performing the operation, S becomes 5 7 7 7 5 results 31 which is the maximum total seats possible.
     */
    public class StellarSeatingMaximization {
        public static void Main() {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for(var i = 0; i < testCaseCount; i++) {
                var inputLineSplit = Console.ReadLine().Split();
                var n = Convert.ToInt32(inputLineSplit[0]);
                var y = Convert.ToInt32(inputLineSplit[1]);

                var seats = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var result = Solve(n, y, seats);

                Console.WriteLine(result);
            }
        }

        private static long Solve(int n, int y, long[] seats) {
            if(n == 0 || y == 0) return 0L;

            var originalSum = 0L;
            var currentGain = 0L;
            var maxGain = 0L;

            foreach(long val in seats) {
                originalSum += val;
                long gain = (val ^ y) - val;

                currentGain += gain;
                if(currentGain < 0) currentGain = 0;
                if(currentGain > maxGain) maxGain = currentGain;
            }

            return originalSum + Math.Max(0, maxGain);
        }
    }
}