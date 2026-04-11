using System;

namespace Athenaeum.Greedy.He
{
    /*
     * There are 
 bulbs arranged in a row. The state of the bulbs is represented by a binary string bulbs of length 
, the 
 at 
 position in the string represents the bulb is OFF and 
 represents the bulb is ON, where 
. You have to switch OFF all the bulbs by performing following operation atmost 
 times. The operation is defined as:-

Choose any index 
 in the string bulb and turn OFF all the lights having indexes 
 to 
 (inclusive), where 
 is a pre defined number, greater than zero and fixed for all the operations.
The task is to find the smallest value of 
 greater than zero, such that you can turn OFF all the bulbs in atmost 
 operations.

Input format

The first line of input contains two space separated integers, 
 and 
, representing the size of string bulb and maximum number of operations you can perform.
The second line of input contains a binary string, bulbs.
Output format

The output contains a single integer, the minimum possible value of 
 greater than zero such that you are able to turn OFF all the bulbs in atmost 
 operations.

Constraints



Examples
Input

10 4
0101011111
Output

3
Explanation
For l = 1, The operation can be perfomed by choosing following intervals

[1, 1], [3, 3], [5, 5], [6, 6], [7, 7], [8, 8], [9, 9] - 7 operations
For l = 2, The operation can be perfomed by choosing following intervals

[1, 2], [3, 4], [5, 6], [7, 8], [9, 9] - 5 operations
For l = 3, The operation can be perfomed by choosing following intervals

[1, 3], [5, 7], [8, 9] - 3 operations
Hence the answer is 3.
     */
    public class TurnOffLights {
        public static void Main() {
            var inputLineSplit = Console.ReadLine().Split();
            var n = Convert.ToInt32(inputLineSplit[0]);
            var k = Convert.ToInt32(inputLineSplit[1]);

            var bulbs = Console.ReadLine();

            var result = Solve(n, k, bulbs);

            Console.WriteLine(result);
        }

        private static int Solve(int n, int k, string bulbs) {
            var low = 1;
            var high = n;
            var result = n;

            while(low <= high) {
                var mid = low + (high - low) / 2;

                if(CanTurnAllBulbsOff(mid, k, bulbs)) {
                    result = mid; // this length works, try to find a smaller one
                    high = mid - 1;
                } else {
                    low = mid + 1;
                }
            }

            return result;
        }

        private static bool CanTurnAllBulbsOff(int l, int k, string bulbs) {
            var operations = 0;
            var i = 0;

            while(i < bulbs.Length) {
                if(bulbs[i] == '1') {
                    operations += 1;
                    if(operations > k) return false;

                    // jump pointer by l
                    i += l;
                } else {
                    i += 1;
                }
            }

            return true;
        }
    }
}