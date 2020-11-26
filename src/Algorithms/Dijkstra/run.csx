#load "../../DataStructures/Graph/entities.csx"
#load "algorithms.csx"

var graph = new Graph(7);

graph.AddEdge(0, 1, 2);
graph.AddEdge(0, 3, 1);
graph.AddEdge(1, 3, 3);
graph.AddEdge(1, 4, 10);
graph.AddEdge(2, 0, 4);
graph.AddEdge(2, 5, 5);
graph.AddEdge(3, 2, 2);
graph.AddEdge(3, 4, 2);
graph.AddEdge(3, 5, 8);
graph.AddEdge(3, 6, 4);
graph.AddEdge(4, 6, 6);
graph.AddEdge(6, 5, 1);

WriteLine("Adjacency:");
graph.ShowAdjacency();

// Dijkstra
var path = Algorithms.Dijkstra(graph, 0, 5);
WriteLine($"\nDijkstra [0 - 5]: {string.Join(", ", path)}");
