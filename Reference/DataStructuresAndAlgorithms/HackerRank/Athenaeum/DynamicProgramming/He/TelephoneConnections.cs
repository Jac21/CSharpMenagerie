using System;
using System.Linq;

namespace Athenaeum.DynamicProgramming.He
{
    public class TelephoneConnections
    {
        public static void Main()
        {
            string line;
            line = Console.ReadLine();
            var A = Convert.ToInt32(line);
            line = Console.ReadLine();
            var B = Convert.ToInt32(line);

            var out_ = MinMax(A, B);
            Console.Out.WriteLine(string.Join(" ", out_.Select(x => x.ToString()).ToArray()));
        }

        static long[] MinMax(long A, long B)
        {
            // pass out the houses in a balanced fashion to minimize connections
            var housesPerLocality = A / B;
            var extraHouses = A % B;

            var n = housesPerLocality;

            // (# of full buckets + pairs) + (# of base buckets + pairs)
            var min = (extraHouses * (n + 1) * n / 2) + ((B - extraHouses) * (n * (n - 1) / 2));

            // distribute lopsided to maximize connectivity
            var nMax = (A - (B - 1));
            var max = (nMax * (nMax - 1)) / 2;

            return new long[] {min, max};
        }
    }
}