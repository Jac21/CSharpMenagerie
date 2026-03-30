using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    public class MaximizeTheSum
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for(var i = 0; i < testCaseCount; i++) {
                var inputSplit = Console.ReadLine().Split();

                var n = Convert.ToInt32(inputSplit[0]);
                var k = Convert.ToInt32(inputSplit[1]);

                var a = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var result = Solve(n, k, a);

                Console.WriteLine(result);
            }
        }

        private static long Solve(int n, int k, long[] a)
        {
            if (n == 0 || k == 0) return 0;
            
            // build freq
            var frequencyDictionary = new Dictionary<long, long>();

            foreach(var val in a) {
                if(val > 0) {
                    if(frequencyDictionary.ContainsKey(val)) {
                        frequencyDictionary[val] += val;
                    } else {
                        frequencyDictionary[val] = val;
                    }
                }
            }

            return frequencyDictionary
                .Values
                .OrderByDescending(x => x)
                .Take(k)
                .Sum();
        }
    }
}