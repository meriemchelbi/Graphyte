using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Graphyte;

namespace GraphyteTests
{
    public class BinarySearchTreeTest
    {
        [Fact]
        public void InsertByValueAddsNodeToCorrectPosition()
        {
            var root = new BinaryTreeNode<int>(7);
            var node4 = new BinaryTreeNode<int>(4);
            var node5 = new BinaryTreeNode<int>(5);
            var node8 = new BinaryTreeNode<int>(8);
            var node15 = new BinaryTreeNode<int>(15);
            var node20 = new BinaryTreeNode<int>(20);

            root.LeftChild = node4;
            root.RightChild = node15;
            node15.LeftChild = node8;
            node4.RightChild = node5;
            node15.RightChild = node20;

            var expectedNodes = new List<Node<int>>
            {
                root, node4, node5, node8, node15, node20,
            };

            var tree = new BinarySearchTree<int>(root);

            tree.InsertByValue(4);
            tree.InsertByValue(15);
            tree.InsertByValue(8);
            tree.InsertByValue(5);
            tree.InsertByValue(20);

            tree.Root.Should().Be(root);
            tree.Nodes.Should().BeEquivalentTo(expectedNodes);
        }

        [Fact]
        public void DeleteRemovesNodeAndReordersTree()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void FindByValueReturnsCorrectNode()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void FindSmallestReturnsNodeWithSmallestValue()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void FindLargestReturnsNodeWithLargestValue()
        {
            throw new NotImplementedException();
        }
    }
}
