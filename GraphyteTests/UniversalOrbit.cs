using Graphyte;
using System;
using Xunit;

namespace GraphyteTests
{
    public class UniversalOrbit
    {
        [Fact]
        public void IceBreaker()
        {
            var galaxy = new Graph<string>();

            var BodyB = new Node<string>("BAA");
            var BodyC = new Node<string>("CBB");
            var BodyD = new Node<string>("DCC");
            var BodyE = new Node<string>("EDD");
            var BodyF = new Node<string>("FEE");
            var BodyG = new Node<string>("GFF");
            var BodyH = new Node<string>("HGG");
            var BodyI = new Node<string>("IHH");
            var BodyJ = new Node<string>("JII");
            var BodyK = new Node<string>("KJJ");
            var BodyL = new Node<string>("LKK");
            var COM = new Node<string>("COM");

            BodyB.Neighbours.Add(BodyC);
            BodyB.Neighbours.Add(BodyG);
            BodyC.Neighbours.Add(BodyD);
            BodyD.Neighbours.Add(BodyE);
            BodyD.Neighbours.Add(BodyI);
            BodyE.Neighbours.Add(BodyF);
            BodyE.Neighbours.Add(BodyJ);
            BodyG.Neighbours.Add(BodyH);
            BodyJ.Neighbours.Add(BodyK);
            BodyK.Neighbours.Add(BodyL);
            COM.Neighbours.Add(BodyB);

            galaxy.AddNodes(BodyB, BodyC, BodyD, BodyE, BodyF, BodyG, BodyH, BodyI, BodyJ, BodyK, BodyL, COM);

            CalculateTotalOrbits(COM);
        }
        public int CalculateTotalOrbits(Node<string> origin, Node<string> destination, int depth = 0)
        {
            var totalOrbit = origin.Neighbours.Count + depth;
            depth += 1;

            foreach (var neighbour in origin.Neighbours)
            {
                totalOrbit += CalculateTotalOrbits(neighbour, depth) - 1;
            }

            return totalOrbit;
        }
    }
}
