using System;
using System.Collections.Generic;
using System.Text;

namespace Graphyte
{
    public class BinarySearchTree<T> : Tree<T>
    {
        public BinarySearchTree(BinaryTreeNode<T> root) : base(root)
        {
        }

        public void InsertByValue(T value)
        {
            _nodes.Add(new BinaryTreeNode<T>(value));
        }

        public void DeleteByValue(T value)
        {
            throw new NotImplementedException();
        }

        public Node<T> FindByValue(T value)
        {
            return new Node<T>(value);
        }

        public Node<int> FindSmallest()
        {
            return new Node<int>(0);
        }

        public Node<int> FindLargest()
        {
            return new Node<int>(0);
        }
    }
}
