using FluentAssertions;
using Graphyte;
using System;
using Xunit;

namespace GraphyteTests
{
    public class BinaryTreeNodeTests
    {
        [Fact]
        public void SetLeftChild_NodeWithSmallerValue_AddsNodeAsLeftChild()
        {
            var childNode = new BinaryTreeNode<int>(5);
            var parentNode = new BinaryTreeNode<int>(10)
            {
                LeftChild = childNode
            };

            parentNode.LeftChild.Should().Be(childNode);
        }
        
        [Fact]
        public void SetLeftChild_NodeWithSmallerValue_ExistingLeftChild_ReplacesExistingLeftChild()
        {
            var childNode = new BinaryTreeNode<int>(5);
            var parentNode = new BinaryTreeNode<int>(10) { LeftChild = new BinaryTreeNode<int>(7) };

            parentNode.LeftChild = childNode;

            parentNode.LeftChild.Should().Be(childNode);
        }
        
        [Fact]
        public void SetLeftChild_NodeWithLargerValue_Throws()
        {
            // how can I test it throws? No features for private getters
            var childNode = new BinaryTreeNode<int>(15);
            var parentNode = new BinaryTreeNode<int>(10);
            try
            {
                parentNode.LeftChild = childNode;
            }
            catch (Exception) { }

            parentNode.LeftChild.Should().BeNull();
        }
        
        [Fact]
        public void SetLeftChild_NullNodeExistingLeftChild_RemovesLeftChild()
        {
            var parentNode = new BinaryTreeNode<int>(10)
            {
                LeftChild = new BinaryTreeNode<int>(7)
            };

            parentNode.LeftChild = null;

            parentNode.LeftChild.Should().BeNull();
        }
        
        [Fact]
        public void SetLeftChild_NullNodeNoLeftChild_DoesNothing()
        {
            var parentNode = new BinaryTreeNode<int>(10)
            {
                LeftChild = null
            };

            parentNode.LeftChild.Should().BeNull();
        }
        
        [Fact]
        public void SetRightChild_NodeWithGreaterValue_AddsNodeAsRightChild()
        {
            var childNode = new BinaryTreeNode<int>(15);
            var parentNode = new BinaryTreeNode<int>(10)
            {
                RightChild = childNode
            };

            parentNode.RightChild.Should().Be(childNode);
        }
        
        [Fact]
        public void SetRightChild_NodeWithGreaterValue_ExistingRightChild_ReplacesExistingRightChild()
        {
            var childNode = new BinaryTreeNode<int>(15);
            var parentNode = new BinaryTreeNode<int>(10) { RightChild = new BinaryTreeNode<int>(20) };

            parentNode.RightChild = childNode;

            parentNode.RightChild.Should().Be(childNode);
        }
        
        [Fact]
        public void SetRightChild_NodeWithSmallerValue_Throws()
        {
            // how can I test it throws? No features for private getters
            var childNode = new BinaryTreeNode<int>(5);
            var parentNode = new BinaryTreeNode<int>(10);
            try
            {
                parentNode.RightChild = childNode;
            }
            catch (Exception) { }

            parentNode.RightChild.Should().BeNull();
        }
        
        [Fact]
        public void SetRightChild_NullNodeExistingRightChild_RemovesRightChild()
        {
            var parentNode = new BinaryTreeNode<int>(10)
            {
                RightChild = new BinaryTreeNode<int>(15)
            };

            parentNode.RightChild = null;

            parentNode.RightChild.Should().BeNull();
        }

        [Fact]
        public void SetRightChild_NullNodeNoRightChild_DoesNothing()
        {
            var parentNode = new BinaryTreeNode<int>(10)
            {
                RightChild = null
            };

            parentNode.RightChild.Should().BeNull();
        }

        [Fact]
        public void CompareTo_ComparesBinaryTreeNodeWithGenericNode()
        {
            var binaryNode = new BinaryTreeNode<int>(5);
            var genericNode = new Node<int>(5);

            var result = binaryNode.CompareTo(genericNode);

            result.Should().Be(0);
        }
        
        [Fact]
        public void CompareTo_ComparesTwoBinaryTreeNodes()
        {
            var binaryNode1 = new BinaryTreeNode<int>(5);
            var binaryNode2 = new BinaryTreeNode<int>(5);

            var result = binaryNode1.CompareTo(binaryNode2);

            result.Should().Be(0);
        }
    }
}
