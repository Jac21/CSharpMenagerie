using System;

namespace Athenaeum.Strings.He
{
    public class FindingWindow
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (input.Length < 2)
            {
                Console.WriteLine("");
                return;
            }

            var s = input[0];
            var t = input[1];

            var sLen = s.Length;
            var tLen = t.Length;
            var minLen = int.MaxValue;
            var result = "";

            int sIdx = 0, tIdx = 0;

            while (sIdx < sLen)
            {
                // 1. Forward Pass: Find a valid window
                if (s[sIdx] == t[tIdx])
                {
                    tIdx++;

                    // If we matched all of T
                    if (tIdx == tLen)
                    {
                        var end = sIdx;
                        tIdx--; // Point to the last char of T

                        // 2. Backward Pass: Shrink from the end to find the optimal start
                        var start = sIdx;
                        while (tIdx >= 0)
                        {
                            if (s[start] == t[tIdx])
                            {
                                tIdx--;
                            }

                            start--;
                        }

                        start++; // Adjust start to the correct index

                        // 3. Check if this window is smaller than our current best
                        var currentLen = end - start + 1;
                        if (currentLen < minLen)
                        {
                            minLen = currentLen;
                            result = s.Substring(start, currentLen);
                        }

                        // Reset tIdx for the next forward search
                        // Start searching again from start + 1 to find the next leftmost window
                        sIdx = start;
                        tIdx = 0;
                    }
                }

                sIdx++;
            }

            Console.WriteLine(result);
        }
    }
}