using System;
using System.Collections.Generic;

namespace Athenaeum.Tree
{
    public class UniqueBinarySearchTreesTwo
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            return GenerateTrees(1, n, new List<TreeNode>() {null});
        }

        private IList<TreeNode> GenerateTrees(int left, int right, List<TreeNode> dummyList)
        {
            if (left > right) return dummyList;

            var list = new List<TreeNode>();

            for (var m = left; m <= right; m++)
            {
                foreach (var leftNode in GenerateTrees(left, m - 1, dummyList))
                {
                    foreach (var rightNode in GenerateTrees(m + 1, right, dummyList))
                    {
                        list.Add(new TreeNode(m, leftNode, rightNode));
                    }
                }
            }

            return list;
        }
    }
}