using System;
using System.Collections.Generic;

namespace Graphyte
{
    public class Node<T>
    {
        public readonly T Value;
        public List<Node<T>> Neighbours { get; }

        public Node(T value)
        {
            Value = value;
            Neighbours = new List<Node<T>>();
        }

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

    }
}
