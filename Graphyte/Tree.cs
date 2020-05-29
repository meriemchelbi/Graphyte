using System;
using System.Collections.Generic;

namespace Graphyte
{
    public class Tree<T> : Graph<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public Tree(Node<T> root) : base()
        {
            Root = root;
            _nodes = new List<Node<T>> { root };
        }
    }
}
