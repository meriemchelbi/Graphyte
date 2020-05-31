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
            if (toRemove.GetRightChild() is null)
            {
                if (position < 0)
                {
                    parent.SetLeftChild(toRemove.GetLeftChild()); // replace parent left child with left child of the node you want to remove;
                }
                else if (position > 0)
                {
                    parent.SetRightChild(toRemove.GetLeftChild()); // replace parent right child with left child of the node you want to remove;
                }
                else
                    throw new Exception("Current node is the same as its parent... You've got a bug! (or a single node tree)");
            }

            // Case 2: if toRemove right child has no left child replace with rightChild
            else if (toRemove.GetRightChild().GetLeftChild() is null)
            {
                if (position < 0)
                {
                    parent.SetLeftChild(toRemove.GetRightChild()); // replace parent right child with left child of the node you want to remove;
                    parent.GetLeftChild().SetLeftChild(toRemove.GetLeftChild() ?? null);
                }
                else if (position > 0)
                {
                    parent.SetRightChild(toRemove.GetRightChild()); // replace parent right child with right child of the node you want to remove;
                    parent.GetRightChild().SetLeftChild(toRemove.GetLeftChild() ?? null);
                }
                else
                    throw new Exception("Current node is the same as its parent... You've got a bug! (or a single node tree)");
            }

            // Case 3: if toRemove right child has left child replace with toRemove.rightChild's leftmost descendant
            else if (toRemove.GetRightChild().GetLeftChild() != null)
            {
                if (position < 0)
                {
                    parent.SetLeftChild(FindLeftmostDescendant(toRemove.GetRightChild()));
                    parent.GetLeftChild().SetLeftChild(toRemove.GetLeftChild() ?? null);
                    parent.GetLeftChild().SetRightChild(toRemove.GetRightChild() ?? null);
                }
                else if (position > 0)
                {
                    parent.SetRightChild(FindLeftmostDescendant(toRemove.GetRightChild()));
                    parent.GetRightChild().SetLeftChild(toRemove.GetLeftChild() ?? null);
                    parent.GetRightChild().SetRightChild(toRemove.GetRightChild() ?? null);
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
                    current = current.GetLeftChild();
                }

                else if (comparison > 0)
                {
                    parent = current;
                    current = current.GetRightChild();
                }
            }

            var relativeToParent = value.CompareTo(parent.Value);

            if (relativeToParent < 0)
            {
                parent.SetLeftChild(new BinaryTreeNode<T>(value));
                _nodes.Add(parent.GetLeftChild());
                return;
            }
            else if (relativeToParent > 0)
            {
                parent.SetRightChild(new BinaryTreeNode<T>(value));
                _nodes.Add(parent.GetRightChild());
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
                node = node.GetLeftChild();
                return TryMatchRecursive(value, node);
            }
            if (value.CompareTo(node.Value) > 0)
            {
                node = node.GetRightChild();
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
            if (node.GetLeftChild() is null)
                return node;
            else return GetLeftmostChild(node.GetLeftChild());
        }

        private BinaryTreeNode<T> GetRightmostChild(BinaryTreeNode<T> node)
        {
            if (node is null)
                throw new NullReferenceException("Node is null!");
            if (node.GetRightChild() is null)
                return node;
            else return GetRightmostChild(node.GetRightChild());
        }

        private BinaryTreeNode<T> FindLeftmostDescendant(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> result = null;

            while (result == null)
            {
                if (node.GetLeftChild() != null)
                    node = node.GetLeftChild();
                
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
                if (node.GetRightChild() is null)
                {
                    node.SetLeftChild(new BinaryTreeNode<T>(value));
                    _nodes.Add(node.GetLeftChild());
                    return;
                }
                else
                    TryInsertRecursive(value, node.GetLeftChild());
            }

            if (value.CompareTo(node.Value) > 0)
            {
                if (node.GetRightChild() is null)
                {
                    node.SetRightChild(new BinaryTreeNode<T>(value));
                    _nodes.Add(node.GetRightChild());
                    return;
                }
                else
                    TryInsertRecursive(value, node.GetRightChild());
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
                    current = current.GetRightChild();
                }
                else if (comparison < 0) // value is smaller than current node search left subtree
                {
                    parent = current;
                    current = current.GetLeftChild();
                }

                if (current is null)
                    return current;
                else comparison = value.CompareTo(current.Value);
            }

            return current;
        }
    }
}
