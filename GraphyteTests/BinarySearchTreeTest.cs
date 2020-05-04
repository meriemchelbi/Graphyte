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
        private BinaryTreeNode _root;
        private BinaryTreeNode _node4;
        private BinaryTreeNode _node5;
        private BinaryTreeNode _node8;
        private BinaryTreeNode _node15;
        private BinaryTreeNode _node20;

        public BinarySearchTreeTest()
        {
            _root = new BinaryTreeNode(7);
            _node4 = new BinaryTreeNode(4);
            _node5 = new BinaryTreeNode(5);
            _node8 = new BinaryTreeNode(8);
            _node15 = new BinaryTreeNode(15);
            _node20 = new BinaryTreeNode(20);

            _root.LeftChild = _node4;
            _root.RightChild = _node15;
            _node15.LeftChild = _node8;
            _node4.RightChild = _node5;
            _node15.RightChild = _node20;
        }

        [Fact]
        public void InsertByValue_AddsNodeToCorrectPosition()
        {
            var expectedNodes = new List<Node<int>>
            {
                _root, _node4, _node5, _node8, _node15, _node20,
            };

            var tree = new BinarySearchTree(new BinaryTreeNode(7));

            tree.InsertByValue(4);
            tree.InsertByValue(15);
            tree.InsertByValue(8);
            tree.InsertByValue(5);
            tree.InsertByValue(20);

            tree.Root.Should().BeEquivalentTo(_root);
            tree.Nodes.Should().BeEquivalentTo(expectedNodes);
        }

        [Fact]
        public void InsertByValue_Throws_WhenDuplicateValue()
        {
            var tree = new BinarySearchTree(_root);

            tree.Invoking(t => t.InsertByValue(7))
                .Should().Throw<Exception>()
                .WithMessage("There is already a node with this value in the tree. Go climb some other tree");
        }

        [Fact]
        public void Case1_DeleteByValue_ReplacesNodeWithLeftChild_IfHasNoRightChild()
        {
            var node18 = new BinaryTreeNode(18);
            _node20.LeftChild = node18;

            var expectedNodes = new List<Node<int>>
            {
                _root, _node4, _node5, _node8, _node15, node18,
            };

            var tree = ConstructBaseTestTree();
            tree.InsertByValue(18);
            var parentNode = tree.FindByValue(15);

            tree.DeleteByValue(20);

            tree.Nodes.Should().BeEquivalentTo(expectedNodes);
            parentNode.RightChild.Value.Should().Be(18);
        }

        [Fact]
        public void Case2_DeleteByValue_ReplacesNodeWithRightChild_IfRightChildHasNoLeftChild()
        {
            var expectedNodes = new List<Node<int>>
            {
                _root, _node4, _node5, _node8, _node20,
            };

            var tree = ConstructBaseTestTree();
            var parentNode = tree.FindByValue(20);

            tree.DeleteByValue(15);

            tree.Nodes.Should().BeEquivalentTo(expectedNodes);
            _root.RightChild.Value.Should().Be(20);
            parentNode.LeftChild.Value.Should().Be(8);
        }
        
        [Fact]
        public void Case3_DeleteByValue_ReplacesNodeWithRightChildsLeftmostDescendant_IfRightChildHasLeftChild()
        {
            var node18 = new BinaryTreeNode(18);
            var node16 = new BinaryTreeNode(16);

            _node20.LeftChild = node18;
            node18.LeftChild = node16;

            var expectedNodes = new List<Node<int>>
            {
                _root, _node4, _node5, _node8, _node20, node18, node16
            };

            var tree = ConstructBaseTestTree();
            tree.InsertByValue(18);
            tree.InsertByValue(16);
            var parentNode = tree.FindByValue(16);

            tree.DeleteByValue(15);

            tree.Nodes.Should().BeEquivalentTo(expectedNodes);
            tree.Root.RightChild.Value.Should().Be(16);
            parentNode.RightChild.Value.Should().Be(20);
        }

        // TODO implement a find by value that uses Linq to traverse the _nodes list and benchmark vs this one
        [Fact]
        public void FindByValueReturnsCorrectNode()
        {
            var tree = new BinarySearchTree(_root);

            var result = tree.FindByValue(15);

            result.Should().Be(_node15);
        }

        [Fact]
        public void FindSmallestReturnsNodeWithSmallestValue()
        {
            var tree = new BinarySearchTree(_root);

            var result = tree.FindSmallest();

            result.Should().Be(_node4);
        }

        [Fact]
        public void FindLargestReturnsNodeWithLargestValue()
        {
            var root = new BinaryTreeNode(7);
            var node4 = new BinaryTreeNode(4);
            var node5 = new BinaryTreeNode(5);
            var node8 = new BinaryTreeNode(8);
            var node15 = new BinaryTreeNode(15);
            var node20 = new BinaryTreeNode(20);

            root.LeftChild = node4;
            root.RightChild = node15;
            node15.LeftChild = node8;
            node4.RightChild = node5;
            node15.RightChild = node20;

            var tree = new BinarySearchTree(root);

            var result = tree.FindLargest();

            result.Should().Be(node20);
        }


        private static BinarySearchTree ConstructBaseTestTree()
        {
            var tree = new BinarySearchTree(new BinaryTreeNode(7));

            tree.InsertByValue(4);
            tree.InsertByValue(15);
            tree.InsertByValue(8);
            tree.InsertByValue(5);
            tree.InsertByValue(20);

            return tree;
        }
    }
}
