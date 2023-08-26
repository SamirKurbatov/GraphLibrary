using GraphLibrary;
using GraphLibrary.Extensions;


var graph = new Graph(4);

var weigths = new Dictionary<Edge, double>();

weigths[graph.AddIncidentNode(0, 1)] = 1;
weigths[graph.AddIncidentNode(0, 2)] = 2;
weigths[graph.AddIncidentNode(0, 3)] = 6;
weigths[graph.AddIncidentNode(1, 3)] = 4;
weigths[graph.AddIncidentNode(2, 3)] = 2;

var path = GraphLogic.Dijkstra(graph, weigths, graph[0], graph[3]);

foreach (var item in path)
{
    Console.WriteLine(item.Number);
}

//var conected = graph.FindDependingComponents();
//Console.WriteLine(conected
//    .Select(component => component
//        .Select(node => node.Number.ToString())
//        .Aggregate((a, b) => a + " " + b))
//    .Aggregate((x, y) => x + "\n" + y));

//var path = graph.FindShortPath(graph[0], graph[4]);

//Console.WriteLine(path.Select(x => x.Number.ToString()).Aggregate((a, b) => a + " " + b));