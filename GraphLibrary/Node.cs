using System.Net.Http.Headers;

namespace GraphLibrary;

public class Edge
{
    public readonly Node From;

    public readonly Node To;

    public Edge(Node from, Node to)
    {
        From = from;
        To = to;
    }

    public bool IsIncident(Node node)
    {
        return From == node || To == node;
    }

    public Node OtherNode(Node node)
    {
        if (From == node)
        {
            return To;
        }

        else if (To == node)
        {
            return From;
        }
        else
        {
            throw new ArgumentException();
        }

    }
}

public class Node
{
    public Node(int number)
    {
        Number = number;
    }

    public int Number { get; init; }

    private readonly List<Edge> edges = new List<Edge>();

    public IEnumerable<Node> Nodes => edges.Select(x => x.OtherNode(this));

    public IEnumerable<Edge> InciditEdges
    {
        get
        {
            return edges.Where(x => x.IsIncident(this));
        }
    }

    public static void AddIncidentNode(Node from, Node to, Graph graph)
    {
        if (!graph.Nodes.Contains(from) || !graph.Nodes.Contains(to))
        {
            throw new ArgumentException();
        }

        var edge = new Edge(from, to);

        from.edges.Add(edge);
        to.edges.Add(edge);
    }
}

public class Graph
{
    private Node[] nodes;

    public int Length => nodes.Length;

    public Node this[int index]
    {
        get => nodes[index];
    }

    public Graph(int count)
    {
        nodes = Enumerable.Range(0, count).Select(x => new Node(x)).ToArray();
    }

    public IEnumerable<Node> Nodes
    {
        get
        {
            foreach (var node in nodes)
            {
                yield return node;
            }
        }
    }

    public IEnumerable<Edge> Edges
    {
        get
        {
            return nodes.SelectMany(z => z.InciditEdges).Distinct();
        }
    }

    private void AddIncidentNode(int v1, int v2)
    {
        Node.AddIncidentNode(nodes[v1], nodes[v2], this);
    }

    public static Graph Create(params int[] incidentNodes)
    {
        var graph = new Graph(incidentNodes.Max() + 1);

        for (int i = 0; i < incidentNodes.Length; i += 2)
        {
            graph.AddIncidentNode(incidentNodes[i], incidentNodes[i + 1]);
        }
        return graph;
    }
}
