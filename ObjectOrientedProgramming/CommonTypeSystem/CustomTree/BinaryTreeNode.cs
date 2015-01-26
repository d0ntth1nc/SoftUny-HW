using System;

namespace CustomTree
{
    public sealed class BinaryTreeNode<T> : TreeNode<T> where T : IComparable<T>
    {
        public BinaryTreeNode()
        {
            this.Children.Add(null);
            this.Children.Add(null);
        }

        public BinaryTreeNode(T value)
            : base(value, null, null) { }

        public BinaryTreeNode(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
            : base(value, left, right) { }

        public BinaryTreeNode<T> Left
        {
            get { return (BinaryTreeNode<T>)this.Children[0]; }
            set { this.Children[0] = value; }
        }

        public BinaryTreeNode<T> Right
        {
            get { return (BinaryTreeNode<T>)this.Children[1]; }
            set { this.Children[1] = value; }
        }
    }
}