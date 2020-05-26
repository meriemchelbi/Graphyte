using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Graphyte;

namespace GraphyteTests
{
    public class GraphTest
    {
        [Fact]
        public void FindNodeRetrievesCorrectNode()
        {
            var metallica = new Graph<string, Node<string>>();
            var node1 = new Node<string>("Lars");
            var node2 = new Node<string>("James");
            var node3 = new Node<string>("Kirk");
            var node4 = new Node<string>("Cliff");

            metallica.AddNodes(node1, node2, node3, node4);

            var result = metallica.FindNode("Cliff");

            result.Should().Be(node4);
        }
    }
}
