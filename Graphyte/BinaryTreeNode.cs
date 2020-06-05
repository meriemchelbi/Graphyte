using System;
using System.Linq;

namespace Graphyte
{
    public class BinaryTreeNode<T> : Node<T> where T: IComparable<T>
    {
        public BinaryTreeNode<T> LeftChild
        {
            get { return _leftChild; }
            set { SetLeftChild(value); }
        }
        public BinaryTreeNode<T> RightChild
        {
            get { return _rightChild; }
            set { SetRightChild(value); }
        }

        private BinaryTreeNode<T> _leftChild;
        private BinaryTreeNode<T> _rightChild;
        private bool IsLeftChild { get; set; }
        private bool IsRightChild { get; set; }
        
        public BinaryTreeNode(T value) : base(value)
        {
        }

        public void RemoveLeftChild()
        {
            var leftChild = Neighbours.Cast<BinaryTreeNode<T>>().FirstOrDefault(n => n.IsLeftChild);
            if (leftChild != null)
            {
                leftChild.IsLeftChild = false;
                Neighbours.Remove(leftChild);
                _leftChild = null;
            }
        }

        public void RemoveRightChild()
        {
            var rightChild = Neighbours.Cast<BinaryTreeNode<T>>().FirstOrDefault(n => n.IsRightChild);
            if (rightChild != null)
            {
                rightChild.IsRightChild = false;
                Neighbours.Remove(rightChild);
                _rightChild = null;
            }
        }
        
        private void SetRightChild(BinaryTreeNode<T> target)
        {
            if (target is null)
            {
                RemoveRightChild();
                return;
            }

            if (target.CompareTo(this) < 0)
            {
                throw new Exception("Value of right child cannot be smaller than value of node");
            }

            var existingRightChild = Neighbours.Cast<BinaryTreeNode<T>>().FirstOrDefault(n => n.IsRightChild);
            
            if (existingRightChild != null)
                RemoveRightChild();

            target.IsRightChild = true;
            target.IsLeftChild = false;
            Neighbours.Add(target);
            _rightChild = target;
        }
        
        private void SetLeftChild(BinaryTreeNode<T> target)
        {
            if (target is null)
            {
                RemoveLeftChild();
                return;
            }

            if (target.CompareTo(this) > 0)
            {
                throw new Exception("Value of left child cannot be greater than value of node");
            }

            var existingLeftChild = Neighbours.Cast<BinaryTreeNode<T>>().FirstOrDefault(n => n.IsLeftChild);
            
            if (existingLeftChild != null)
                RemoveLeftChild();

            target.IsLeftChild = true;
            target.IsRightChild = false;
            Neighbours.Add(target);
            _leftChild = target;
        }
    }
}
