#load "../../DataStructures/Graph/entities.csx"

public static class Algorithms
{
    public static List<int> TopologicalSort(Graph graph)
    {
        var result = new List<int>();
        var node = 0;

        while ((node = FindIndigree0(graph)) != -1)
        {
            result.Add(node);
            DecreaseIndigree(graph, node);
        }

        return result;
    }

    private static int FindIndigree0(Graph graph)
    {
        for (var i = 0; i < graph.Nodes; i++)
        {
            if (graph.Indigree[i] == 0)
            {
                return i;
            }
        }

        return -1;
    }

    private static void DecreaseIndigree(Graph graph, int node)
    {
        graph.Indigree[node] = -1;

        for (var i = 0; i < graph.Nodes; i++)
        {
            if (graph.Adjacency[node, i] == 1)
            {
                graph.Indigree[i]--;
            }
        }
    }
}
