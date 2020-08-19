public class Graph
{
    public int[,] Adjacency { get; private set; }
    public int[] Indigree { get; private set; } // Indigree: edge number to node
    public int Nodes { get; private set; }

    public Graph(int nodes)
    {
        Nodes = nodes;
        Adjacency = new int[nodes, nodes];
        Indigree = new int[nodes];
    }

    public void AddEdge(int start, int end)
    {
        Adjacency[start, end] = 1;
    }

    public void AddEdge(int start, int end, int weight)
    {
        Adjacency[start, end] = weight;
    }

    public int GetAdjacency(int start, int end)
    {
        return Adjacency[start, end];
    }

    public void ShowAdjacency()
    {
        // Row headers
        for (var i = 0; i < Nodes; i++)
        {
            Console.Write($"\t({i})");
        }

        Console.WriteLine();

        for (var i = 0; i < Nodes; i++)
        {
            // Column headers
            Console.Write($"({i})");

            // Adjacency values
            for (var j = 0; j < Nodes; j++)
            {
                Console.Write($"\t {Adjacency[i, j]}");
            }

            Console.WriteLine();
        }
    }

    public void IndigreeCalculation()
    {
        for (var i = 0; i < Nodes; i++)
        {
            for (var j = 0; j < Nodes; j++)
            {
                if (Adjacency[j, i] == 1)
                {
                    Indigree[i]++;
                }
            }
        }
    }

    public void ShowIndigree()
    {
        for (var i = 0; i < Nodes; i++)
        {
            Console.WriteLine($"({i}): {Indigree[i]}");
        }
    }
}
