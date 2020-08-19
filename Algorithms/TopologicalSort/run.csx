#load "../../DataStructures/Graph/entities.csx"
#load "algorithms.csx"

var graph = new Graph(7);

graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(0, 3);
graph.AddEdge(1, 3);
graph.AddEdge(1, 4);
graph.AddEdge(2, 5);
graph.AddEdge(3, 2);
graph.AddEdge(3, 5);
graph.AddEdge(3, 6);
graph.AddEdge(4, 3);
graph.AddEdge(4, 6);
graph.AddEdge(6, 5);
graph.IndigreeCalculation();

Console.WriteLine("Adjacency:");
graph.ShowAdjacency();

Console.WriteLine("\nIndigree:");
graph.ShowIndigree();

var sort = Algorithms.TopologicalSort(graph);
Console.WriteLine($"\nTopological sort: {string.Join(", ", sort)}");
