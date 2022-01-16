using System;
using System.Collections.Generic;

namespace HackerRank.Tree
{
    public class UniqueBinarySearchTrees
    {
        private readonly Dictionary<int, int> _dictionary = new Dictionary<int, int>()
        {
            [0] = 1
        };

        public int NumTrees(int n)
        {
            if (_dictionary.ContainsKey(n))
            {
                return _dictionary[n];
            }

            var num = 0;
            for (var i = 0; i < n; i++)
            {
                var rightCount = n - i - 1;

                var leftNum = NumTrees(i);
                var rightNum = NumTrees(rightCount);

                num += leftNum * rightNum;
            }

            _dictionary[n] = num;
            return num;
        }
    }
}