using System;
using System.Collections.Generic;
using System.Text;

namespace Graphyte
{
    public class BinaryTreeNode : Node<int>
    {
        public BinaryTreeNode LeftChild { get; set; }
        public BinaryTreeNode RightChild { get; set; }
        //private int myVar;

        //public BinaryTreeNode LeftChild
        //{
        //    get { return Neighbours[0]; }
        //    set { myVar = value; }
        //}


        public BinaryTreeNode(int value) : base(value)
        {
        }
    }
}
