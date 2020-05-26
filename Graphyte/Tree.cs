using System;
using System.Collections.Generic;
using System.Text;

namespace Graphyte
{
    public class Tree<T, TNode> : Graph<T> where TNode : Node<T>
    {
        public TNode Root { get; protected set; }

        public Tree(TNode root)
        {
            Root = root;
            _nodes.Add(root);
        }
    }
}
