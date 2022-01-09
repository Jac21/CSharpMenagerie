using System;
using System.Collections.Generic;

namespace HackerRank.DynamicProgramming
{
    public static class LongestValidParentheses
    {
        public static int FindLongestValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var max = 0;
            var extraClosures = -1;

            var openParens = new Stack<int>();

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] is '(')
                {
                    openParens.Push(i);
                }
                else if (openParens.Count is 0 || extraClosures > openParens.Peek())
                {
                    extraClosures = i;
                }
                else
                {
                    openParens.Pop();

                    max = Math.Max(max,
                        openParens.Count is 0 ? i - extraClosures : i - Math.Max(extraClosures, openParens.Peek()));
                }
            }

            return max;
        }
    }
}