using System.Collections.Generic;

namespace CustomTree
{
    public class TreeNode<T>
    {
        public TreeNode()
        {
            this.Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value, params TreeNode<T>[] children)
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>(children);
        }

        public List<TreeNode<T>> Children { get; set; }

        public T Value { get; set; }
    }
}
