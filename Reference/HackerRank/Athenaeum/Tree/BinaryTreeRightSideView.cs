using System.Collections.Generic;

namespace Athenaeum.Tree
{
    public class BinaryTreeRightSideView
    {
        public IList<int> RightSideView(TreeNode root)
        {
            var results = new List<int>();

            RightSideView(root, 0, results);

            return results;
        }

        private static void RightSideView(TreeNode root, int level, List<int> results)
        {
            if (root == null) return;

            if(results.Count <= level) results.Add(root.Val);

            level += 1;
            
            RightSideView(root.Right, level, results);
            RightSideView(root.Left, level, results);
        }
    }
}