using GraphLibrary;
using GraphLibrary.Extensions;

var graph = Graph.Create(
        0,1,1,2,2,0
    );

var res = GraphLogic.TarjanAlgorithm(graph);

foreach (var item in res)
{
    Console.WriteLine(item.Number);
}

var s = GraphLogic.HasCycle(graph.Nodes);

Console.WriteLine(s);

var conected = graph.FindDependingComponents();
Console.WriteLine(conected
    .Select(component => component
        .Select(node => node.Number.ToString())
        .Aggregate((a, b) => a + " " + b))
    .Aggregate((x, y) => x + "\n" + y));

var path = graph.FindShortPath(graph[0], graph[4]);

Console.WriteLine(path.Select(x => x.Number.ToString()).Aggregate((a, b) => a + " " + b));