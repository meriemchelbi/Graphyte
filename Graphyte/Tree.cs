using System;
using System.Collections.Generic;
using System.Text;

namespace Graphyte
{
    public class Tree<T> : Graph<T>
    {
        public Node<T> Root { get; }

        public Tree(Node<T> root)
        {
            Root = root;
        }
    }
}
