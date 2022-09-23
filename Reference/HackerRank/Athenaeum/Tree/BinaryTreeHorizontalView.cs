using System;
using System.Collections.Generic;

namespace Athenaeum.Tree
{
    public class BinaryTreeHorizontalView
    {
        public IList<int> HorizontalView(TreeNode root)
        {
            var results = new List<int>();
            var nodeDictionary = new Dictionary<int, int>();

            for (var i = HorizontalView(root, 0, nodeDictionary) + 1; nodeDictionary.ContainsKey(i); i++)
            {
                results.Add(nodeDictionary[i]);
            }

            return results;
        }

        private static int HorizontalView(TreeNode root, int level, Dictionary<int, int> nodeDictionary)
        {
            if (root == null) return level;

            if (!nodeDictionary.ContainsKey(level)) nodeDictionary.Add(level, root.Val);

            return Math.Min(
                HorizontalView(root.Left, level - 1, nodeDictionary),
                HorizontalView(root.Right, level + 1, nodeDictionary));
        }
    }
}