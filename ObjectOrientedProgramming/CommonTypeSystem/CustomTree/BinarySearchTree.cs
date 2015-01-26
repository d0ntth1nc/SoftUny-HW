using System;
using System.Collections.Generic;

namespace CustomTree
{
    public class BinarySearchTree<T> : ICollection<T>, IEnumerable<T>, ICloneable where T : IComparable<T>
    {
        public BinarySearchTree() { }

        public BinarySearchTree(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public BinaryTreeNode<T> Root { get; private set;}

        public int Count { get; private set; }

        public virtual void Add(T item)
        {
            if (this.Root == null)
                this.Root = new BinaryTreeNode<T>(item);
            else
            {
                var nodeTuple = DFS(item);
                var current = nodeTuple.Item1;
                var parent = nodeTuple.Item2;
                if (current != null)
                    throw new InvalidOperationException("Cannot add duplicate item!");

                int result = item.CompareTo(parent.Value);
                if (result < 0)
                    parent.Left = new BinaryTreeNode<T>(item);
                else
                    parent.Right = new BinaryTreeNode<T>(item);
            }

            this.Count++;
        }

        public void Clear()
        {
            this.Root = null;
            this.Count = 0;
        }

        public virtual bool Contains(T item)
        {
            if (this.Count == 0) return false;

            return DFS(item).Item1 != null;
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public virtual bool Remove(T item)
        {
            if (this.Count == 0) return false;

            var nodesTuple = DFS(item);
            var current = nodesTuple.Item1;
            var parent = nodesTuple.Item2;

            if (current == null) return false;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    this.Root = current.Left;
                }
                else
                {
                    int result = parent.Value.CompareTo(current.Value);

                    if (result > 0)
                        parent.Left = current.Left;
                    else if (result < 0)
                        parent.Right = current.Left;
                }    
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                    this.Root = current.Right;
                else
                {
                    int result = parent.Value.CompareTo(current.Value);
                    if (result > 0)
                        parent.Left = current.Right;
                    else if (result < 0)
                        parent.Right = current.Right;
                }
            }
            else
            {
                BinaryTreeNode<T> leftMost = current.Right.Left, leftMostParent = current.Right;
                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;

                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                    this.Root = leftMost;
                else
                {
                    int result = parent.Value.CompareTo(current.Value);
                    if (result > 0)
                        parent.Left = leftMost;
                    else if (result < 0)
                        parent.Right = leftMost;
                }
            }

            this.Count--;
            return true;
        }

        public object Clone()
        {
            return new BinarySearchTree<T>(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<BinaryTreeNode<T>>();
            if (this.Root != null) queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
                yield return currentNode.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private Tuple<BinaryTreeNode<T>, BinaryTreeNode<T>> DFS(T item)
        {
            BinaryTreeNode<T> current = this.Root, parent = null;
            while (current != null)
            {
                int result = item.CompareTo(current.Value);
                if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result == 0)
                {
                    return new Tuple<BinaryTreeNode<T>, BinaryTreeNode<T>>(current, parent);
                }
                else
                {
                    parent = current;
                    current = current.Right;
                }
            }

            return new Tuple<BinaryTreeNode<T>, BinaryTreeNode<T>>(current, parent);
        }
    }
}