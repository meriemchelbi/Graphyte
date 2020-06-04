using System;

namespace Graphyte
{
    public class BinarySearchTree<T> : Tree<T, BinaryTreeNode<T>> where T : IComparable<T>
    {
        public BinarySearchTree(BinaryTreeNode<T> root) : base(root)
        {
        }

        public void InsertByValue(T value)
        {
            TryInsert(value, Root);
        }

        public void InsertByValueRecursive(T value)
        {
            TryInsertRecursive(value, Root);
        }

        public void DeleteByValue(T value)
        {
            BinaryTreeNode<T> parent = null;

            var toRemove = FindNodeAndParent(value, Root, ref parent);

            var position = toRemove.CompareTo(parent); 

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
                    var replacement = FindLeftmostDescendant(toRemove.RightChild);
                    FindParentNode(replacement).RemoveLeftChild();
                    parent.RightChild = replacement;
                    parent.RightChild.LeftChild = toRemove.LeftChild ?? null;
                    parent.RightChild.RightChild = toRemove.RightChild ?? null;
                }
                else
                    throw new Exception("Current node is the same as its parent... You've got a bug! (or a single node tree)");
            }

            _nodes.Remove(toRemove);
        }

        public BinaryTreeNode<T> FindByValueRecursive(T value)
        {
            return TryMatchRecursive(value, Root);
        }

        public BinaryTreeNode<T> FindSmallest()
        {
            return GetLeftmostChild(Root);
        }

        public BinaryTreeNode<T> FindLargest()
        {
            return GetRightmostChild(Root);
        }
        
        public void TryInsert(T value, BinaryTreeNode<T> startNode)
        {
            if (startNode is null)
                throw new NullReferenceException("Node is null!");

            BinaryTreeNode<T> current = startNode;
            BinaryTreeNode<T> parent = null;

            while (current != null)
            {
                var comparison = value.CompareTo(current.Value);

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

            var relativeToParent = value.CompareTo(parent.Value);

            if (relativeToParent < 0)
            {
                parent.LeftChild = new BinaryTreeNode<T>(value);
                _nodes.Add(parent.LeftChild);
                return;
            }
            else if (relativeToParent > 0)
            {
                parent.RightChild = new BinaryTreeNode<T>(value);
                _nodes.Add(parent.RightChild);
                return;
            }
        }

        private BinaryTreeNode<T> TryMatchRecursive(T value, BinaryTreeNode<T> node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");
            if (value.CompareTo(node.Value) == 0)
            {
                return node;
            }
            if (value.CompareTo(node.Value) < 0)
            {
                node = node.LeftChild;
                return TryMatchRecursive(value, node);
            }
            if (value.CompareTo(node.Value) > 0)
            {
                node = node.RightChild;
                return TryMatchRecursive(value, node);
            }
            else
            {
                return null;
            }
        }

        private BinaryTreeNode<T> GetLeftmostChild(BinaryTreeNode<T> node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");
            if (node.LeftChild is null)
                return node;
            else return GetLeftmostChild(node.LeftChild);
        }

        private BinaryTreeNode<T> GetRightmostChild(BinaryTreeNode<T> node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");
            if (node.RightChild is null)
                return node;
            else return GetRightmostChild(node.RightChild);
        }

        private BinaryTreeNode<T> FindLeftmostDescendant(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> result = null;

            while (result == null)
            {
                if (node.LeftChild != null)
                    node = node.LeftChild;
                
                else result = node;
            }

            return result;
        }

        private void TryInsertRecursive(T value, BinaryTreeNode<T> node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");
            
            if(value.CompareTo(node.Value) == 0)
                throw new Exception("There is already a node with this value in the tree. Go climb some other tree");

            if (value.CompareTo(node.Value) < 0)
            {
                if (node.RightChild is null)
                {
                    node.LeftChild = new BinaryTreeNode<T>(value);
                    _nodes.Add(node.LeftChild);
                    return;
                }
                else
                    TryInsertRecursive(value, node.LeftChild);
            }

            if (value.CompareTo(node.Value) > 0)
            {
                if (node.RightChild is null)
                {
                    node.RightChild = new BinaryTreeNode<T>(value);
                    _nodes.Add(node.RightChild);
                    return;
                }
                else
                    TryInsertRecursive(value, node.RightChild);
            }
        }

        private BinaryTreeNode<T> FindNodeAndParent(T value, BinaryTreeNode<T> current, ref BinaryTreeNode<T> parent)
        {
            var comparison = value.CompareTo(current.Value);

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
                else comparison = value.CompareTo(current.Value);
            }

            return current;
        }

        private BinaryTreeNode<T> FindParentNode(BinaryTreeNode<T> node)
        {
            var current = Root;
            var comparison = node.CompareTo(current);
            BinaryTreeNode<T> parent = null;

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
                    return parent;
                else comparison = node.CompareTo(current);
            }

            return parent;
        }
    }
}
