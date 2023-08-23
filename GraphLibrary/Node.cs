using System.Net.Http.Headers;

namespace GraphLibrary;

public class Node
{
    public Node(int number)
    {
        Number = number;
    }

    public int Number { get; init; }

    private readonly List<Edge> edges = new List<Edge>();

    public IEnumerable<Node> IncidentNodes => edges.Select(x => x.OtherNode(this));

    public IEnumerable<Edge> InciditEdges
    {
        get
        {
            foreach (var item in edges)
            {
                yield return item;
            }
        }
    }

    public static Edge AddIncidentNode(Node from, Node to, Graph graph)
    {
        if (!graph.Nodes.Contains(from) || !graph.Nodes.Contains(to))
        {
            throw new ArgumentException();
        }

        var edge = new Edge(from, to);

        from.edges.Add(edge);
        to.edges.Add(edge);

        return edge;
    }
}
