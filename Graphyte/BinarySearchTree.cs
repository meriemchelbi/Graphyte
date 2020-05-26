using System;

namespace Graphyte
{
    public class BinarySearchTree : Tree<int, BinaryTreeNode>
    {
        public BinarySearchTree Tree { get; set; }

        public BinarySearchTree(BinaryTreeNode root) : base(root)
        {
        }

        public void InsertByValue(int value)
        {
            TryInsert(value, Root);
        }

        public void InsertByValueRecursive(int value)
        {
            TryInsertRecursive(value, Root);
        }

        public void DeleteByValue(int value)
        {
            BinaryTreeNode parent = null;

            var toRemove = FindNodeAndParent(value, Root, ref parent);

            // TODO ask node- equality comparer-ish
            //public class EdgeCost : IComparable<EdgeCost>
            //{
            //    public int Cost { get; set; }
            //    public int CompareTo(EdgeCost other)
            //    {
            //        if (ReferenceEquals(this, other)) return 0;
            //        if (ReferenceEquals(null, other)) return 1;
            //        return Cost.CompareTo(other.Cost);
            //    }
            //}
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
                    throw new Exception("Current node is the same as its parent... You've got a bug! (or a single node tree)");
            }

            // Case 2: if toRemove right child has no left child replace with rightChild
            else if (toRemove.RightChild.LeftChild is null)
            {
                if (position < 0)
                {
                    parent.LeftChild = toRemove.RightChild; // replace parent right child with left child of the node you want to remove;
                    parent.LeftChild.LeftChild = toRemove.LeftChild ?? null;
                }
                else if (position > 0)
                {
                    parent.RightChild = toRemove.RightChild; // replace parent right child with right child of the node you want to remove;
                    parent.RightChild.LeftChild = toRemove.LeftChild ?? null;
                }
                else
                    throw new Exception("Current node is the same as its parent... You've got a bug! (or a single node tree)");
            }

            // Case 3: if toRemove right child has left child replace with toRemove.rightChild's leftmost descendant
            else if (toRemove.RightChild.LeftChild != null)
            {
                if (position < 0)
                {
                    parent.LeftChild = FindLeftmostDescendant(toRemove.RightChild);
                    parent.LeftChild.LeftChild = toRemove.LeftChild ?? null;
                    parent.LeftChild.RightChild = toRemove.RightChild ?? null;
                }
                else if (position > 0)
                {
                    parent.RightChild = FindLeftmostDescendant(toRemove.RightChild);
                    parent.RightChild.LeftChild = toRemove.LeftChild ?? null;
                    parent.RightChild.RightChild = toRemove.RightChild ?? null;
                }
                else
                    throw new Exception("Current node is the same as its parent... You've got a bug! (or a single node tree)");
            }

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
        
        public void TryInsert(int value, BinaryTreeNode node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");

            BinaryTreeNode current = node;
            BinaryTreeNode parent= null;

            while (current != null)
            {
                var comparison = Compare(value, node);

                if (comparison == 0)
                    throw new Exception("There is already a node with this value in the tree. Go climb some other tree");

                if (comparison < 0)
                {
                    parent = current;
                    current = current.LeftChild;
                }

                else if (comparison > 0)
                {
                    parent = current;
                    current = current.RightChild;
                }
            }

            if (parent == null)
            {
                Root = node;
            }

            var relativeToParent = Compare(value, parent);
            if (relativeToParent < 0)
            {
                parent.LeftChild = new BinaryTreeNode(value);
                AddNode(parent.LeftChild);
                return;
            }
            else if (relativeToParent > 0)
            {
                parent.RightChild = new BinaryTreeNode(value);
                AddNode(parent.RightChild);
                return;
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

        private BinaryTreeNode FindLeftmostDescendant(BinaryTreeNode node)
        {
            BinaryTreeNode result = null;

            while (result == null)
            {
                if (node.LeftChild != null)
                {
                    node = node.LeftChild;
                }
                else result = node;
            }

            return result;
        }

        private void TryInsertRecursive(int value, BinaryTreeNode node)
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
                    AddNode(node.LeftChild);
                    return;
                }
                else
                    TryInsertRecursive(value, node.LeftChild);
            }

            if (value > node.Value)
            {
                if (node.RightChild is null)
                {
                    node.RightChild = new BinaryTreeNode(value);
                    AddNode(node.RightChild);
                    return;
                }
                else
                    TryInsertRecursive(value, node.RightChild);
            }
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
