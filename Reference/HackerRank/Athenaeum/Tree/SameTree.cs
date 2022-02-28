using System;

namespace Athenaeum.Tree
{
    // Definition for a binary tree node.

    public static class SameTree
    {
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if (p != null && q != null)
            {
                if (p.Val == q.Val)
                {
                    return IsSameTree(p.Left, q.Left) &&
                           IsSameTree(p.Right, q.Right);
                }

                return false;
            }

            return false;
        }
    }
}