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

        public int CountShortestDistance(Node<T> origin, Node<T> destination)
        {

            var originParents = new List<Node<T>>();
            var destinationParents = new List<Node<T>>();
            FindNodeParents(origin, ref originParents);
            FindNodeParents(destination, ref destinationParents);
            var mutualParent = originParents.Intersect(destinationParents).FirstOrDefault();
            var result = originParents.IndexOf(mutualParent) + destinationParents.IndexOf(mutualParent);
            return result;
        }

        private List<Node<T>> FindNodeParents(Node<T> child, ref List<Node<T>> result)
        {
            foreach (var node in _nodes)
            {
                if (node.Neighbours.Contains(child))
                {
                    result.Add(node);
                    FindNodeParents(node, ref result);
                }
            }

            return result;
        }
    }
}
