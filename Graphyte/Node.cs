using System;
using System.Collections.Generic;

namespace Graphyte
{
    public class Node<T>
    {
        private readonly T _value;
        public List<Node<T>> Neighbours { get; set; }

        public Node(T value)
        {
            _value = value;
        }


    }
}
