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

        public void DeleteByValue(int value)
        {
            throw new NotImplementedException();
        }

        public Node<int> FindByValue(int value)
        {
            return TryMatch(value, Root);
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

        public Node<int> FindSmallest()
        {
            return new Node<int>(0);
        }

        public Node<int> FindLargest()
        {
            return new Node<int>(0);
        }
    }
}
