using System.Collections.Generic;
using System.Linq;

namespace Graphyte
{
    public class Graph<T>
    {
        private readonly List<Node<T>> _nodes;

        public Graph()
        {
            _nodes = new List<Node<T>>();
        }

        public void AddNode(Node<T> node)
        {
            _nodes.Add(node);
        }

        public void AddNodes(params Node<T>[] nodes)
        {
            _nodes.AddRange(nodes);
        }

        public Node<T> FindNode(T value)
        {
            return _nodes.Where(n => n.Value.Equals(value)).First();
        }
    }
}
