using GraphLibrary;
using GraphLibrary.Extensions;

var graph = Graph.Create(
    1, 2,
    2, 3,
    3, 4,
    4, 5,
    5, 6,
    6, 7,
    7, 8,
    7, 112
    );

Console.WriteLine("Обход в глубину: ");

Console.WriteLine(graph[1]
    .DepthSearch()
    .Select(x => x.Number.ToString())
    .Aggregate((x, y) => x + " " + y));

Console.WriteLine("Обход в ширину: ");

Console.WriteLine(graph[1].WidthSearch().Select(x => x.Number.ToString())
    .Aggregate((x, y) => x + " " + y));
