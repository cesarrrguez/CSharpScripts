#load "entities.csx"

public static class Algorithms
{
    public static HashSet<T> BFS<T>(Graph<T> graph, T start)
    {
        var visited = new HashSet<T>();

        if (!graph.AdjacencyList.ContainsKey(start))
        {
            return visited;
        }

        var queue = new Queue<T>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();

            if (visited.Contains(vertex))
            {
                continue;
            }

            visited.Add(vertex);

            foreach (var neighbor in graph.AdjacencyList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return visited;
    }
}
