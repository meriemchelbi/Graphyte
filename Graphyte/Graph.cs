using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphyte
{
    public class Graph<T, TNode> where TNode : Node<T> where T : IComparable<T>
    {
        public List<TNode> Nodes
        {
            get { return _nodes; }
            private set { }
        }

        protected List<TNode> _nodes;

        public Graph()
        {
            _nodes = new List<TNode>();
        }

        public void AddNode(TNode node)
        {
            _nodes.Add(node);
        }

        public void AddNodes(params TNode[] nodes)
        {
            _nodes.AddRange(nodes);
        }

        public TNode FindNode(T value)
        {
            return _nodes.Where(n => n.Value.Equals(value)).First();
        }

        // TODO: try implementing without having to traverse the entire tree to the root.
        public int CountShortestDistance(TNode origin, TNode destination)
        {
            var originParents = new List<TNode>();
            var destinationParents = new List<TNode>();

            FindNodeParents(origin, originParents);
            FindNodeParents(destination, destinationParents);

            var mutualParent = originParents.Intersect(destinationParents).FirstOrDefault();

            return originParents.IndexOf(mutualParent) + destinationParents.IndexOf(mutualParent);
        }

        private List<TNode> FindNodeParents(TNode child, List<TNode> result)
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
