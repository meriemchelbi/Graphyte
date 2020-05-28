using System;
using System.Collections.Generic;
using System.Text;

namespace Graphyte
{
    public class BinaryTreeNode : Node<int>
    {
        public BinaryTreeNode LeftChild 
        {
            get { return Neighbours[0]; }
            set { Neighbours[0] = value; }
        }
        public BinaryTreeNode RightChild
        {
            get { return Neighbours[1]; }
            set { Neighbours[1] = value; }
        }
        public BinaryTreeNode(int value) : base(value)
        {
        }
    }
}
