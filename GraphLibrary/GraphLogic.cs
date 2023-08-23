namespace GraphLibrary;

public static class GraphLogic
{
    public enum State
    {
        White,
        Gray,
        Black
    }

    public static List<Node> TarjanAlgorithm(Graph graph)
    {
        var topSort = new List<Node>();

        var states = graph.Nodes.ToDictionary(node => node, state => State.White);

        while (true)
        {
            var nodeToSearch = states
                .Where(x => x.Value == State.White)
                .Select(x => x.Key)
                .FirstOrDefault();
            if (nodeToSearch == null)
            {
                break;
            }

            if (!TarjanDepthSearch(nodeToSearch, states, topSort))
            {
                return null;
            }
        }
        topSort.Reverse();
        return topSort;
    }

    private static bool TarjanDepthSearch(Node nodeToSearch, Dictionary<Node, State> states, List<Node> topSort)
    {
        if (states[nodeToSearch] == State.Gray) return false;
        if (states[nodeToSearch] == State.Black) return true;

        states[nodeToSearch] = State.Gray;

        var outhoingNodes = nodeToSearch.InciditEdges
            .Where(e => e.From == nodeToSearch)
            .Select(e => e.To);

        foreach (var nextNode in outhoingNodes)
        {
            if (!TarjanDepthSearch(nextNode, states, topSort))
            {
                return false;
            }
        }

        states[nodeToSearch] = State.Black;
        topSort.Add(nodeToSearch);
        return true;
    }

    public static bool HasCycle(List<Node> graph)
    {
        var visited = new HashSet<Node>(); // Серые вершины
        var finished = new HashSet<Node>();
        var stack = new Stack<Node>();
        visited.Add(graph.FirstOrDefault());
        stack.Push(graph.FirstOrDefault());
        while (stack.Count != 0)
        {
            var node = stack.Pop();
            foreach (var nextNode in node.IncidentNodes)
            {
                if (finished.Contains(node))
                {
                    continue;
                }

                if (visited.Contains(nextNode))
                {
                    return true;
                }

                stack.Push(nextNode);
                visited.Add(nextNode);
            }
            finished.Add(node);
        }
        return false;
    }
}
