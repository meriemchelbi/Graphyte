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
            var existingRightChild = Neighbours.Cast<BinaryTreeNode<T>>().FirstOrDefault(n => n.IsRightChild);
            
            if (existingRightChild != null)
            {
                Neighbours.Remove(existingRightChild);
                existingRightChild.IsRightChild = false;
            }

            target.IsRightChild = true;
            target.IsLeftChild = false;
            Neighbours.Add(target);
        }
        
        public void SetLeftChild(BinaryTreeNode<T> target)
        {
            var existingLeftChild = Neighbours.Cast<BinaryTreeNode<T>>().FirstOrDefault(n => n.IsLeftChild);
            
            if (existingLeftChild != null)
            {
                Neighbours.Remove(existingLeftChild);
                existingLeftChild.IsLeftChild = false;
            }

            target.IsLeftChild = true;
            target.IsRightChild = false;
            Neighbours.Add(target);
        }

        public int CompareTo(BinaryTreeNode<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
