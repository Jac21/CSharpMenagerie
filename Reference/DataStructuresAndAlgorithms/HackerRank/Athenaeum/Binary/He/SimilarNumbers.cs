using System;
using System.Linq;

namespace Athenaeum.Binary.He
{
    public class SimilarNumbers
    {
        private static int Solver(string testCase) {
            if(string.IsNullOrEmpty(testCase)) return 0;

            // derive and parse input
            var testCaseSplit = testCase.Split(' ');

            var x = Convert.ToInt32(testCaseSplit.FirstOrDefault());
            var y = Convert.ToInt32(testCaseSplit.Skip(1).FirstOrDefault());

            // xor values
            var xorValue = x ^ y;

            var sum = 0;
            while(xorValue != 0) {
                sum += (xorValue & 1);
                xorValue >>= 1;
            }

            return sum;
        }
    }
}