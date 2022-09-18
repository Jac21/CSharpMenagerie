using System.Collections.Generic;

namespace Athenaeum.Tree
{
    public class TreeNode
    {
        public readonly int Val;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            Val = val;
            Left = left;
            Right = right;
        }
    }

    public class TreeNodeWrapper
    {
        public int val;
        public List<TreeNodeWrapper> children;

        public TreeNodeWrapper()
        {
            val = 0;
            children = new List<TreeNodeWrapper>();
        }

        public TreeNodeWrapper(int _val)
        {
            val = _val;
            children = new List<TreeNodeWrapper>();
        }

        public TreeNodeWrapper(int _val, List<TreeNodeWrapper> _children)
        {
            val = _val;
            children = _children;
        }
    }
}