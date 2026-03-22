using System;

namespace Athenaeum.Arrays
{
    public static class MedianOfTwoSortedArrays
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null) throw new ArgumentNullException(nameof(nums1));
            if (nums2 == null) throw new ArgumentNullException(nameof(nums2));
            
            var merged = new int[nums1.Length + nums2.Length];

            var i = 0;
            var j = 0;
            var k = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    merged[k] = nums1[i];

                    i++;
                    k++;
                }
                else
                {
                    merged[k] = nums2[j];

                    j++;
                    k++;
                }
            }

            while (i < nums1.Length)
            {
                merged[k] = nums1[i];

                i++;
                k++;
            }

            while (j < nums2.Length)
            {
                merged[k] = nums2[j];

                j++;
                k++;
            }

            var mid = merged.Length / 2;
            if (merged.Length % 2 == 0)
            {
                return (merged[mid - 1] + merged[mid]) / 2.0;
            }

            return merged[mid];
        }
    }
}