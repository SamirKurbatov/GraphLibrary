using GraphLibrary;
using GraphLibrary.Extensions;

var graph = Graph.Create(
        0, 1,
            0, 2,
            1, 4,
            2, 3,
            3, 4
    );


var conected = graph.FindDependingComponents();
Console.WriteLine(conected
    .Select(component => component
        .Select(node => node.Number.ToString())
        .Aggregate((a, b) => a + " " + b))
    .Aggregate((x, y) => x + "\n" + y));

var path = graph.FindShortPath(graph[0], graph[4]);

Console.WriteLine(path.Select(x => x.Number.ToString()).Aggregate((a, b) => a + " " + b));