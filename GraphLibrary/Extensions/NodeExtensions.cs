namespace GraphLibrary.Extensions;

public static class NodeExtensions
{
    public static IEnumerable<Node> DepthSearch(this Node node)
    {
        var stack = new Stack<Node>();
        var visited = new HashSet<Node>();

        visited.Add(node);
        stack.Push(node);

        while (stack.Count != 0)
        {
            var currentNode = stack.Pop();
            yield return currentNode;

            foreach (var incideantNode in currentNode.IncidentNodes.Where(z => !visited.Contains(z)))
            {
                visited.Add(incideantNode);
                stack.Push(incideantNode);
            }
        }
    }

    public static IEnumerable<Node> WidthSearch(this Node node)
    {
        var queue = new Queue<Node>();
        var visited = new HashSet<Node>();

        visited.Add(node);
        queue.Enqueue(node);

        while (queue.Count != 0)
        {
            var currentNode = queue.Dequeue();
            yield return currentNode;

            foreach (var incideantNode in currentNode.IncidentNodes.Where(z => !visited.Contains(z)))
            {
                visited.Add(incideantNode);
                queue.Enqueue(incideantNode);
            }
        }
    }
}
