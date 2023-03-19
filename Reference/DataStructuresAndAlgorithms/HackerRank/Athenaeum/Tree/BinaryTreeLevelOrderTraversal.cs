using System;
using System.Collections.Generic;

namespace Athenaeum.Tree
{
    public class BinaryTreeLevelOrderTraversal
    {
        private IList<IList<int>> _result = new List<IList<int>>();

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            TraverseRecursively(root, 0);

            return _result;
        }

        private void TraverseRecursively(TreeNode node, int currentDepth)
        {
            if (node == null || node.Val == 0) return;

            if (_result.Count == currentDepth) _result.Add(new List<int>());

            _result[currentDepth].Add(node.Val);

            TraverseRecursively(node.Left, currentDepth + 1);
            TraverseRecursively(node.Right, currentDepth + 1);
        }
    }
}