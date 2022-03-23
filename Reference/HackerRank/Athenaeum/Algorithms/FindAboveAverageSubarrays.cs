using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Algorithms
{
    public class FindAboveAverageSubarrays
    {
        public static Subarray[] AboveAverageSubarrays(int[] A)
        {
            if (A.Length == 0) return Array.Empty<Subarray>();

            var subarrayList = new List<Subarray>();

            var totalSum = A.Sum();

            for (var i = 0; i < A.Length; i++)
            {
                int currentSum = 0;

                for (int j = i; j < A.Length; j++)
                {
                    currentSum += A[j];

                    if (currentSum / (j - i + 1) > (totalSum - currentSum)
                        / (A.Length - (j - i + 1)))
                    {
                        subarrayList.Add(new Subarray
                        {
                            Left = i + 1,
                            Right = j + 1
                        });
                    }
                }
            }

            return subarrayList.ToArray();
        }
    }

    public class Subarray
    {
        public int Left;

        public int Right;
    }
}

/*
 * Above-Average Subarrays
You are given an array A containing N integers. Your task is to find all subarrays whose average sum is greater than the average sum of the remaining array elements. You must return the start and end index of each subarray in sorted order.
A subarray that starts at position L1 and ends at position R1 comes before a subarray that starts at L2 and ends at R2 if L1 < L2, or if L1 = L2 and R1 ≤ R2.
Note that we'll define the average sum of an empty array to be 0, and we'll define the indicies of the array (for the purpose of output) to be 1 through N. A subarray that contains a single element will have L1 = R1.
Signature
Subarray[] aboveAverageSubarrays(int[] A)
Input
1 ≤ N ≤ 2,000
1 ≤ A[i] ≤ 1,000,000
Output
A Subarray is an object with two integer fields, left and right, defining the range that a given subarray covers. Return a list of all above-average subarrays sorted as explained above.
Example 1
A = [3, 4, 2]
output = [[1, 2], [1, 3], [2, 2]]
The above-average subarrays are [3, 4], [3, 4, 2], and [4].
*/