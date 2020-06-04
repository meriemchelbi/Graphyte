using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            leftChild.IsLeftChild = false;
            Neighbours.Remove(leftChild);
        }

        public void RemoveRightChild()
        {
            var rightChild = Neighbours.Cast<BinaryTreeNode<T>>().FirstOrDefault(n => n.IsRightChild);
            rightChild.IsRightChild = false;
            Neighbours.Remove(rightChild);
        }
        
        private void SetRightChild(BinaryTreeNode<T> target)
        {
            if (target is null)
            {
                RemoveRightChild();
                return;
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
