#load "../../DataStructures/Graph/entities.csx"

public static class Algorithms
{
    public static List<int> ShortestPath(Graph graph, int start, int end)
    {
        var path = new List<int>();

        var info = CreateGraphInfo(graph, start);
        //ShowGraphInfo(info);

        FillGraphInfo(graph, info);
        //ShowGraphInfo(info);

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

    private static void FillGraphInfo(Graph graph, int[,] info)
    {
        for (var i = 0; i < graph.Nodes; i++)
        {
            for (var j = 0; j < graph.Nodes; j++)
            {
                if (info[j, 0] == 0 && info[j, 1] == i)
                {
                    info[j, 0] = 1; // Visited

                    for (var k = 0; k < graph.Nodes; k++)
                    {
                        if (graph.GetAdjacency(j, k) == 1)
                        {
                            if (info[k, 1] == int.MaxValue)
                            {
                                info[k, 1] = i + 1;
                                info[k, 2] = j;
                            }
                        }
                    }
                }
            }
        }
    }

    // private static void ShowGraphInfo(int[,] info)
    // {
    //     WriteLine("\nGraph info:");

    //     for (var i = 0; i < info.GetLength(0); i++)
    //     {
    //         WriteLine("{0} -> {1}\t{2}\t{3}", i, info[i, 0], info[i, 1], info[i, 2]);
    //     }
    // }
}
