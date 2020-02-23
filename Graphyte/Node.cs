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


    }
}
