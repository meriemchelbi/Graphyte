using Graphyte;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphyteBenchmarks
{
    public class TreeGrower
    {
        public BinarySearchTree BuildTree()
        {
            return new BinarySearchTree(new BinaryTreeNode(5));
        }
    }
}
