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
            BinaryTreeNode parent = null;

            var toRemove = FindNodeAndParent(value, Root, ref parent);
            
            var position = Compare(toRemove.Value, parent);

            // Case 1: if toRemove has no right child replace with leftChild
            if (toRemove.RightChild is null)
            {
                if (position < 0)
                {
                    parent.LeftChild = toRemove.LeftChild; // replace parent left child with left child of the node you want to remove;
                }
                else if (position > 0)
                {
                    parent.RightChild = toRemove.LeftChild; // replace parent right child with left child of the node you want to remove;
                }
                else
                {
                    throw new Exception("Current node is the same as its parent... You've got a bug! (or a single node tree)");
                }
            }

            // Case 2: if toRemove right child has no left child replace with dn rightChild
            // Case 3: if toRemove right child has left child replace with dn rightChild's leftmost descendant

            _nodes.Remove(toRemove);
        }

        public BinaryTreeNode FindByValueRecursive(int value)
        {
            return TryMatchRecursive(value, Root);
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

        private BinaryTreeNode TryMatchRecursive(int value, BinaryTreeNode node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");
            if (value == node.Value)
            {
                return node;
            }
            if (value < node.Value)
            {
                node = node.LeftChild;
                return TryMatchRecursive(value, node);
            }
            if (value > node.Value)
            {
                node = node.RightChild;
                return TryMatchRecursive(value, node);
            }
            else
            {
                return null;
            }
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

        private BinaryTreeNode FindNodeAndParent(int value, BinaryTreeNode current, ref BinaryTreeNode parent)
        {
            var comparison = Compare(value, current);

            while (comparison != 0)
            {
                if (comparison > 0) // value is bigger than current node search right subtree
                {
                    parent = current;
                    current = current.RightChild;
                }
                else if (comparison < 0) // value is smaller than current node search left subtree
                {
                    parent = current;
                    current = current.LeftChild;
                }

                if (current is null)
                    return current;
                else comparison = Compare(value, current);
            }

            return current;
        }

        private int Compare(int value, BinaryTreeNode node)
        {
            return value - node.Value;
        }
    }
}
