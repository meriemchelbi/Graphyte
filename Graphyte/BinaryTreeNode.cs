using System;
using System.Collections.Generic;
using System.Text;

namespace Graphyte
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        public BinaryTreeNode(T value) : base(value)
        {
        }
    }
}
