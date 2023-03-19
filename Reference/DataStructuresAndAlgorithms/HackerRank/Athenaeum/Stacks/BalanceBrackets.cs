using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Stacks
{
    public static class BalanceBrackets
    {
        public static bool IsBalanced(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            var openBrackets = new Stack<char>();

            foreach (var bracket in s)
            {
                if (bracket is '(' ||
                    bracket is '{' ||
                    bracket is '[')
                {
                    openBrackets.Push(bracket);
                }
                else
                {
                    if (openBrackets.TryPop(out var openBracket))
                    {
                        if (openBracket is '(' && bracket != ')' ||
                            openBracket is '{' && bracket != '}' ||
                            openBracket is '[' && bracket != ']')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return !openBrackets.Any();
        }
    }
}