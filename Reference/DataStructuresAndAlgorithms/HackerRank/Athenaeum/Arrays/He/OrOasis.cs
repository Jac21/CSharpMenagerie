using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    public class OrOasis
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

                Solve(n, a);
            }
        }

        private static void Solve(int n, int[] a)
        {
            if (n == 0) Console.WriteLine("-1");

            // precompute prefid and suffix
            var prefix = new int[n];
            var suffix = new int[n];
            prefix[0] = a[0];
            for (var i = 1; i < n; i++) prefix[i] = prefix[i - 1] | a[i];

            suffix[n - 1] = a[n - 1];
            for (var i = n - 2; i >= 0; i--) suffix[i] = suffix[i + 1] | a[i];

            var totalOr = prefix[n - 1];
            var minLen = int.MaxValue;
            var count = 0L;

            // slide
            var bitCounts = new int[31];
            var currentInsideOr = 0;
            var left = 0;

            for (int right = 0; right < n; right++)
            {
                //update bit frequency array
                for (var b = 0; b < 31; b++)
                {
                    if (((a[right] >> b) & 1) == 1)
                    {
                        if (bitCounts[b] == 0)
                        {
                            currentInsideOr |= (1 << b);
                        }

                        bitCounts[b]++;
                    }
                }

                while (left <= right && currentInsideOr == totalOr)
                {
                    // calculate OR of everythig outside of [left, right]
                    var outsideOr = 0;

                    if (left > 0)
                    {
                        outsideOr |= prefix[left - 1];
                    }

                    if (right < n - 1)
                    {
                        outsideOr |= suffix[right + 1];
                    }

                    if (outsideOr == totalOr)
                    {
                        var currentLength = right - left + 1;

                        if (currentLength < minLen)
                        {
                            minLen = currentLength;
                            count = 1;
                        }
                        else if (currentLength == minLen)
                        {
                            count += 1;
                        }
                    }

                    for (var b = 0; b < 31; b++)
                    {
                        if (((a[left] >> b) & 1) == 1)
                        {
                            bitCounts[b]--;

                            if (bitCounts[b] == 0)
                            {
                                currentInsideOr &= ~(1 << b);
                            }
                        }
                    }

                    left += 1;
                }
            }

            if (minLen == int.MaxValue) Console.WriteLine("-1");
            else Console.WriteLine($"{minLen} {count}");
        }
    }
}