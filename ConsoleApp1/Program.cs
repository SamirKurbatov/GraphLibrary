using GraphLibrary;

var graph = Graph.Create(
    1,2,
    3,4,
    5,6
    );

foreach (var item in graph.Edges)
{
    Console.WriteLine($"From: {item.From.Number}\nTo: {item.To.Number}");
}