using System;
using System.Collections.Generic;
using System.Text;

namespace Graphyte
{
    public class BinaryTreeNode<T> : Node<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> LeftChild 
        {
            get { return Neighbours[0] as BinaryTreeNode<T>; } // null-safe syntax
            set { Neighbours[0] = value; }
        }
        public BinaryTreeNode<T> RightChild
        {
            get { return Neighbours[1] as BinaryTreeNode<T>; }
            set { Neighbours[1] = value; }
        }
        public BinaryTreeNode(T value) : base(value)
        {
        }
    }
}
