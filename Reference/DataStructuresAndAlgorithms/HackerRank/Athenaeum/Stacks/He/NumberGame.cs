using System.Collections.Generic;
using System.Text;

namespace Athenaeum.Stacks.He
{
    public class NumberGame
    {
        private static string Solver(string relation) {
            if(string.IsNullOrEmpty(relation)) {
                return string.Empty;
            }
            var rollCount = relation.Length;

            // derive pattern
            var pattern = new char[rollCount];
            for(var i = 0; i < rollCount; i++) {
                var val = relation[i] - '0';
                pattern[i] = (val % 2 == 0) ? 'I' : 'D';
            }

            var stack = new Stack<int>();
            var output = new StringBuilder();

            for(var i = 0; i <= rollCount; i++) {
                stack.Push(i + 1);

                if(i == rollCount || pattern[i] == 'I') {
                    while(stack.Count > 0) {
                        output.Append(stack.Pop());
                    }
                }
            }

            return output.ToString();
        }
    }
}