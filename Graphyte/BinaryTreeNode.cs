using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphyte
{
    public class BinaryTreeNode<T> : Node<T> where T: IComparable<T>
    {
        public bool IsLeftChild { get; set; }
        public bool IsRightChild { get; set; }
        public BinaryTreeNode(T value) : base(value)
        {
        }

        public BinaryTreeNode<T> GetRightChild()
        {
            return Neighbours.Cast<BinaryTreeNode<T>>().FirstOrDefault(n => n.IsRightChild);
        }
        
        public BinaryTreeNode<T> GetLeftChild()
        {
            return Neighbours.Cast<BinaryTreeNode<T>>().FirstOrDefault(n => n.IsLeftChild);
        }

        public void SetRightChild(BinaryTreeNode<T> target)
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
        }
        
        public void SetLeftChild(BinaryTreeNode<T> target)
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

        public int CompareTo(BinaryTreeNode<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
