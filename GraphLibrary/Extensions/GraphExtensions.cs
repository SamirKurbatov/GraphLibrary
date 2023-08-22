namespace GraphLibrary.Extensions;

public static class GraphExtensions
{
    public static IEnumerable<IEnumerable<Node>> FindDependingComponents(this Graph graph)
    {
        var result = new List<List<Node>>();
        var markedNodes = new HashSet<Node>();

        while (true)
        {
            var nextNode = graph.Nodes
                .Where(node => !markedNodes
                .Contains(node))
                .FirstOrDefault();

            if (nextNode == null) { break; }

            var breadthSearch = nextNode.WidthSearch().ToList();

            result.Add(breadthSearch);
            foreach (var node in breadthSearch)
            {
                markedNodes.Add(node);
            }
        }

        return result;
    }

    public static IEnumerable<Node> FindShortPath(this Graph graph, Node start, Node finish)
    {
        var track = new Dictionary<Node, Node>();
        track[start] = null;
        var queue = new Queue<Node>();
        queue.Enqueue(start);
        while (queue.Count != 0)
        {
            var prevNode = queue.Dequeue();

            foreach (var nextNode in prevNode.InciditNodes)
            {
                if (track.ContainsKey(nextNode))
                {
                    continue;
                }
                track[nextNode] = prevNode;
                queue.Enqueue(nextNode);
            }
            if (track.ContainsKey(finish)) break;
        }
        var result = new List<Node>();

        while (finish != null)
        {
            result.Add(finish);
            finish = track[finish];
        }
        result.Reverse();
        return result;
    }
}
