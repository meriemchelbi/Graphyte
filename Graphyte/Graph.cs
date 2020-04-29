using System.Collections.Generic;
using System.Linq;

namespace Graphyte
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes
        {
            get { return _nodes; }
            private set { }
        }

        protected List<Node<T>> _nodes;

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

        // TODO: try implementing without having to traverse the entire tree to the root.
        public int CountShortestDistance(Node<T> origin, Node<T> destination)
        {
            var originParents = new List<Node<T>>();
            var destinationParents = new List<Node<T>>();

            FindNodeParents(origin, originParents);
            FindNodeParents(destination, destinationParents);

            var mutualParent = originParents.Intersect(destinationParents).FirstOrDefault();

            return originParents.IndexOf(mutualParent) + destinationParents.IndexOf(mutualParent);
        }

        private List<Node<T>> FindNodeParents(Node<T> child, List<Node<T>> result)
        {
            foreach (var node in _nodes)
            {
                if (node.Neighbours.Contains(child))
                {
                    result.Add(node);
                    FindNodeParents(node, result);
                }
            }

            return result;
        }
    }
}
