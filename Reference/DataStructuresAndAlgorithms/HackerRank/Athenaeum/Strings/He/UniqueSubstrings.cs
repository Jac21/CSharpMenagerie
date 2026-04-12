using System;

namespace Athenaeum.Strings.He
{
    public class UniqueSubstrings
    {
        public static void Main()
        {
            var s = Console.ReadLine();
            var line = Console.ReadLine();
            int k = Convert.ToInt32(line);

            int @out = Solve(s, k);
            Console.Out.WriteLine(@out);
        }

        private static int Solve(string s, int k)
        {
            if (k == 0 || k == 1) return 0;

            var lastSeenArray = new int[26];
            for (var i = 0; i < lastSeenArray.Length; i++)
            {
                lastSeenArray[i] = -1;
            }

            var duplicateCount = 0;
            var stringLength = s.Length;

            for (var i = 0; i < stringLength; i++)
            {
                var charValue = s[i] - 'a';

                if (lastSeenArray[charValue] != -1 && i - lastSeenArray[charValue] < k)
                {
                    duplicateCount += 1;
                }
                else
                {
                    lastSeenArray[charValue] = i;
                }
            }

            return duplicateCount;
        }
    }
}