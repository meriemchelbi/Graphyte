using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using Graphyte;

namespace GraphyteBenchmarks
{
    [MemoryDiagnoser, ShortRunJob]
    public class BinarySearchTreeBenchmarks
    {
        [Benchmark]
        public void BenchmarkInsertByValue()
        {
            var tree = ConstructTree();
            tree.InsertByValue(20);
        }

        [Benchmark]
        public void BenchmarkInsertByValueRecursive()
        {
            var tree = ConstructTree();
            tree.InsertByValueRecursive(20);
        }

        private BinarySearchTree<int> ConstructTree()
        {
            var root = new BinaryTreeNode<int>(7);
            var node4 = new BinaryTreeNode<int>(4);
            var node5 = new BinaryTreeNode<int>(5);
            var node8 = new BinaryTreeNode<int>(8);
            var node15 = new BinaryTreeNode<int>(15);

            root.LeftChild = node4;
            root.RightChild = node15;
            node15.LeftChild = node8;
            node4.RightChild = node5;

            return new BinarySearchTree<int>(root);
        }
    }
}
