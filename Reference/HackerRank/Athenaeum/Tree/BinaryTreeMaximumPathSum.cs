using System;

namespace Athenaeum.Tree
{
    public static class BinaryTreeMaximumPathSum
    {
        private static int _maxPath = int.MinValue;

        public static int MaxPathSum(TreeNode root)
        {
            MaxPathSumRecursive(root);

            return _maxPath;
        }

        private static int MaxPathSumRecursive(TreeNode root)
        {
            if (root == null) return 0;

            var left = MaxPathSumRecursive(root.Left);
            var right = MaxPathSumRecursive(root.Right);

            var leftSide = left + root.Val;
            var rightSide = right + root.Val;

            var sum = left + right + root.Val;

            _maxPath = Math.Max(_maxPath, Math.Max(root.Val, Math.Max(sum, Math.Max(leftSide, rightSide))));

            return Math.Max(root.Val, Math.Max(leftSide, rightSide));
        }
    }
}