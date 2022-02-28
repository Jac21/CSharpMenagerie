using System.Collections.Generic;

namespace Athenaeum.Tree
{
    public class BinaryTreeInorderTraversal
    {
        private readonly List<int> _inorderList = new List<int>();

        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null || root.Val == 0) return _inorderList;

            InorderTraversal(root.Left);
            _inorderList.Add(root.Val);
            InorderTraversal(root.Right);

            return _inorderList;
        }

        public IList<int> InorderTraversalIterative(TreeNode root)
        {
            var inorderNodes = new List<int>();
            var nodeStack = new Stack<TreeNode>();

            if (root == null || root.Val == 0) return inorderNodes;

            nodeStack.Push(root);
            var treeNode = root.Left;

            while (nodeStack.Count > 0 || treeNode != null)
            {
                while (treeNode != null)
                {
                    nodeStack.Push(treeNode);
                    treeNode = treeNode.Left;
                }

                treeNode = nodeStack.Pop();
                inorderNodes.Add(treeNode.Val);
                treeNode = treeNode.Right;
            }

            return inorderNodes;
        }
    }
}