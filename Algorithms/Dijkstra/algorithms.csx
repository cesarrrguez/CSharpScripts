#load "../../DataStructures/Graph/entities.csx"

public static class Algorithms
{
    // Dijkstra
    // --------------------------------------------------------------
    //  Find the shortest path between nodes in a graph with weights.
    // --------------------------------------------------------------
    public static List<int> Dijkstra(Graph graph, int start, int end)
    {
        var path = new List<int>();

        var info = CreateGraphInfo(graph, start);
        ShowGraphInfo(info);

        FillGraphInfo(graph, start, info);
        ShowGraphInfo(info);

        var node = end;
        while (node != start)
        {
            path.Add(node);
            node = info[node, 2];
        }
        path.Add(start);

        path.Reverse();

        return path;
    }

    // Graph info
    // 0 - Visited
    // 1 - Distance
    // 2 - Previous
    private static int[,] CreateGraphInfo(Graph graph, int start)
    {
        var result = new int[graph.Nodes, 3];

        for (var i = 0; i < graph.Nodes; i++)
        {
            result[i, 0] = 0;
            result[i, 1] = int.MaxValue;
            result[i, 2] = 0;
        }
        result[start, 1] = 0;

        return result;
    }

    private static void FillGraphInfo(Graph graph, int start, int[,] info)
    {
        var node = start;
        var distance = 0;

        do
        {
            info[node, 0] = 1; // Visited

            for (var i = 0; i < graph.Nodes; i++)
            {
                var nodeAdjacency = graph.GetAdjacency(node, i);

                // Check node connection
                if (nodeAdjacency != 0)
                {
                    // Distance calculation
                    distance = nodeAdjacency + info[node, 1];

                    // Set distance
                    if (distance < info[i, 1])
                    {
                        info[i, 1] = distance;
                        info[i, 2] = node; // Set parent info
                    }
                }
            }

            // We have to find the node with the shortest distance that has not been visited
            var minIndex = -1;
            var minDistance = int.MaxValue;
            for (var i = 0; i < graph.Nodes; i++)
            {
                if (info[i, 1] < minDistance && info[i, 0] == 0)
                {
                    minIndex = i;
                    minDistance = info[i, 1];
                }
            }

            node = minIndex;

        } while (node != -1);
    }

    private static void ShowGraphInfo(int[,] info)
    {
        Console.WriteLine("\nGraph info:");

        for (var i = 0; i < info.GetLength(0); i++)
        {
            Console.WriteLine("{0} -> {1}\t{2}\t{3}", i, info[i, 0], info[i, 1], info[i, 2]);
        }
    }
}
