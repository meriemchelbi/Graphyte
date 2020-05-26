using BenchmarkDotNet.Attributes;
using Graphyte;

namespace GraphyteBenchmarks
{
    [MemoryDiagnoser, ShortRunJob]
    public class BinarySearchTreeBenchmarks
    {
        [Benchmark]
        public void BenchmarkInsertByValue3()
        {
            var tree = Construct3NodeTree();
            tree.InsertByValue(20);
        }

        [Benchmark]
        public void BenchmarkInsertByValueRecursive3()
        {
            var tree = Construct3NodeTree();
            tree.InsertByValueRecursive(20);
        }

        private BinarySearchTree Construct3NodeTree()
        {
            var root = new BinaryTreeNode(7);
            var node4 = new BinaryTreeNode(4);
            var node15 = new BinaryTreeNode(15);

            root.LeftChild = node4;
            root.RightChild = node15;

            return new BinarySearchTree(root);
        }
        
        [Benchmark]
        public void BenchmarkInsertByValue5()
        {
            var tree = Construct5NodeTree();
            tree.InsertByValue(20);
        }

        [Benchmark]
        public void BenchmarkInsertByValueRecursive5()
        {
            var tree = Construct5NodeTree();
            tree.InsertByValueRecursive(20);
        }

        private BinarySearchTree Construct5NodeTree()
        {
            var root = new BinaryTreeNode(7);
            var node4 = new BinaryTreeNode(4);
            var node5 = new BinaryTreeNode(5);
            var node8 = new BinaryTreeNode(8);
            var node15 = new BinaryTreeNode(15);

            root.LeftChild = node4;
            root.RightChild = node15;
            node15.LeftChild = node8;
            node4.RightChild = node5;

            return new BinarySearchTree(root);
        }
        
        [Benchmark]
        public void BenchmarkInsertByValue10(BinarySearchTree tree)
        {
            tree.InsertByValue(20);
        }

        [Benchmark]
        public void BenchmarkInsertByValueRecursive10(BinarySearchTree tree)
        {
            tree.InsertByValueRecursive(20);
        }

        private BinarySearchTree Construct10NodeTree()
        {
            var node1 = new BinaryTreeNode(1);
            var node3 = new BinaryTreeNode(3);
            var node4 = new BinaryTreeNode(4);
            var node5 = new BinaryTreeNode(5);
            var root = new BinaryTreeNode(7);
            var node8 = new BinaryTreeNode(8);
            var node11 = new BinaryTreeNode(11);
            var node15 = new BinaryTreeNode(15);
            var node19 = new BinaryTreeNode(19);
            var node29 = new BinaryTreeNode(29);

            root.LeftChild = node4;
            root.RightChild = node15;
            node15.LeftChild = node8;
            node4.RightChild = node5;
            node4.LeftChild = node3;
            node3.LeftChild = node1;
            node8.RightChild = node11;
            node15.RightChild = node29;
            node29.LeftChild = node19;

            return new BinarySearchTree(root);
        }
    }
}
