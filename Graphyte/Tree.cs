using System.Collections.Generic;

namespace Graphyte
{
    public class Tree<T, TNode> : Graph<T, TNode> where TNode: Node<T>
    {
        public TNode Root { get; set; }

        public Tree(TNode root) : base()
        {
            Root = root;
            _nodes = new List<TNode> { root };
        }
    }
}
