using System;
using System.Collections.Generic;

namespace Graphyte
{
    public class Node<T> : IComparable<Node<T>> where T : IComparable<T>
    {
        public readonly T Value;
        public List<Node<T>> Neighbours { get; }

        public Node(T value)
        {
            Value = value;
            Neighbours = new List<Node<T>>();
        }

        public int CompareTo(Node<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
