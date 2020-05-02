using System;
using System.Collections.Generic;
using System.Text;

namespace Graphyte
{
    public class BinarySearchTree : Tree<int>
    {
        public BinaryTreeNode Root { get; }

        public BinarySearchTree(BinaryTreeNode root) : base(root)
        {
            Root = root;
        }

        public void InsertByValue(int value)
        {
            TryInsert(value, Root);
        }

        

        public void DeleteByValue(int value)
        {
            var toBeDeleted = FindByValue(value);

            // Case 1: if toBeDeleted has no right child replace with leftChild
            // Case 2: if toBeDeleted right child has no left child replace with dn rightChild
            // Case 2: if toBeDeleted right child has left child replace with dn rightChild's leftmost descendant
        }

        public Node<int> FindByValue(int value)
        {
            return TryMatch(value, Root);
        }

        public BinaryTreeNode FindSmallest()
        {
            return TryGetLeftChild(Root);
        }

        public BinaryTreeNode FindLargest()
        {
            return TryGetRightChild(Root);
        }

        private void TryInsert(int value, BinaryTreeNode node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");

            if (value == node.Value)
                throw new Exception("There is already a node with this value in the tree. Go climb some other tree");

            if (value < node.Value)
            {
                if (node.LeftChild is null)
                {
                    node.LeftChild = new BinaryTreeNode(value);
                    _nodes.Add(node.LeftChild);
                    return;
                }
                else
                    TryInsert(value, node.LeftChild);
            }

            if (value > node.Value)
            {
                if (node.RightChild is null)
                {
                    node.RightChild = new BinaryTreeNode(value);
                    _nodes.Add(node.RightChild);
                    return;
                }
                else
                    TryInsert(value, node.RightChild);
            }
        }

        private BinaryTreeNode TryMatch(int value, BinaryTreeNode node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");
            if (value == node.Value)
                return node;
            if (value < node.Value)
                return TryMatch(value, node.LeftChild);
            if (value > node.Value)
                return TryMatch(value, node.RightChild);
            else return null;
        }

        private BinaryTreeNode TryGetLeftChild(BinaryTreeNode node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");
            if (node.LeftChild is null)
                return node;
            else return TryGetLeftChild(node.LeftChild);
        }

        private BinaryTreeNode TryGetRightChild(BinaryTreeNode node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");
            if (node.RightChild is null)
                return node;
            else return TryGetRightChild(node.RightChild);
        }
    }
}
