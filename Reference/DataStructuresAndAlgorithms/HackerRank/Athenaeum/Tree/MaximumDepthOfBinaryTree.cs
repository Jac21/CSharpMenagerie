using System;

namespace Athenaeum.Tree
{
    public static class MaximumDepthOfBinaryTree
    {
        public static int MaxDepth(TreeNode root)
        {
            return SearchTree(root, 0);
        }

        private static int SearchTree(TreeNode node, int currentDepth)
        {
            if (node == null) return currentDepth;

            var leftDepth = SearchTree(node.Left, currentDepth + 1);

            var rightDepth = SearchTree(node.Right, currentDepth + 1);

            return Math.Max(leftDepth, rightDepth);
        }
    }
}