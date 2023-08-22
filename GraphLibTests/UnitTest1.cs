using GraphLibrary;

namespace GraphLibTests
{
    public class Tests
    {
        [Test]
        public void InitNodeTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var node = new Node(i);
                Assert.AreEqual(node.Number, i);
            }
        }

        [Test]
        public void AddToGraph()
        {
            var graph = Graph.Create(0, 1, 2, 3, 4, 5);

            var firstNode = graph.Nodes.FirstOrDefault();
            var secondNode = graph.Nodes.Skip(1).FirstOrDefault();

            var edge = new Edge(firstNode, secondNode);

            bool isIncident = edge.IsIncident(edge.From);

            Assert.AreEqual(true, isIncident);
        }
    }
}