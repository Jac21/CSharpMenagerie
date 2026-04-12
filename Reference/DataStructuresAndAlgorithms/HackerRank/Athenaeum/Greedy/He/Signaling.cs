using System;

namespace Athenaeum.Greedy.He
{
    public class Signaling
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var T = Convert.ToInt32(line);

            for (var t_i = 0; t_i < T; t_i++)
            {
                line = Console.ReadLine();
                var N = Convert.ToInt32(line);
                string S;
                S = Console.ReadLine();

                var out_ = Solve(N, S);
                Console.Out.WriteLine(out_);
            }
        }

        private static int Solve(int N, string S)
        {
            var currentTime = 0;
            var maxTime = 0;

            // iterate over string
            foreach (var level in S)
            {
                if (level == '1')
                {
                    currentTime += 1;
                }
                else
                {
                    maxTime = Math.Max(maxTime, currentTime);

                    // reset
                    currentTime = 0;
                }
            }

            // final check
            return Math.Max(maxTime, currentTime);
        }
    }
}