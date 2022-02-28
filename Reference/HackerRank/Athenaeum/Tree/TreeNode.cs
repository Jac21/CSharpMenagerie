namespace Athenaeum.Tree
{
    public class TreeNode
    {
        public readonly int Val;
        public readonly TreeNode Left;
        public readonly TreeNode Right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            Val = val;
            Left = left;
            Right = right;
        }
    }
}