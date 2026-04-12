using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Stacks.He
{
    public class ChocolateStack
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var N = Convert.ToInt32(line);
            line = Console.ReadLine();
            var C = new long[N];
            C = line.Split().Select(str => long.Parse(str)).ToArray();

            var out_ = Solve(N, C);
            Console.Out.WriteLine(string.Join(" ", out_.Select(x => x.ToString()).ToArray()));
        }

        static long[] Solve(int N, long[] C)
        {
            var inputStack = new Stack<long>();
            var outputList = new List<long>();

            for (var i = 0; i < N; i++)
            {
                if (C[i] != 0)
                {
                    inputStack.Push(C[i]);
                }
                else
                {
                    outputList.Add(inputStack.Pop());
                }
            }

            return outputList
                .ToArray();
        }
    }
}