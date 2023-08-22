namespace GraphLibrary;

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

        for (int i = 0; i < incidentNodes.Length - 1; i += 2)
        {
            graph.AddIncidentNode(incidentNodes[i], incidentNodes[i + 1]);
        }
        return graph;
    }
}
