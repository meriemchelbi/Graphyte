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
            var parent = Root;

            var toRemove = TryMatch(value, ref parent);

            if (toRemove == parent.RightChild)
            {
                if (toRemove.RightChild is null) // Case 1
                {
                    parent.RightChild = toRemove.LeftChild;
                }
            }

            if (toRemove == parent.LeftChild)
            {
                if (toRemove.RightChild is null) // Case 1
                {
                    parent.LeftChild = toRemove.LeftChild;
                }
            }
                        

            _nodes.Remove(toRemove);

            // Case 1: if toRemove has no right child replace with leftChild
            // Case 2: if toRemove right child has no left child replace with dn rightChild
            // Case 3: if toRemove right child has left child replace with dn rightChild's leftmost descendant
        }

        public BinaryTreeNode FindByValue(int value)
        {
            var parent = Root;
            return TryMatch(value, ref parent);
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

        private BinaryTreeNode TryMatch(int value, ref BinaryTreeNode parent)
        {
            if (parent is null)
                throw new NullReferenceException("Node is null!");
            if (value == parent.Value)
            {
                return parent;
            }
            if (value < parent.Value)
            {
                parent = parent.LeftChild;
                return TryMatch(value, ref parent);
            }
            if (value > parent.Value)
            {
                parent = parent.RightChild;
                return TryMatch(value, ref parent);
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
    }
}
