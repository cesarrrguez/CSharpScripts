#load "entities.csx"

public class Algorithm
{
    private readonly List<Node> _graph;
    private readonly Node _origin;
    private readonly int _iterations;
    private List<Route> _solutions;

    public Algorithm(List<Node> graph, Node origin, int iterations)
    {
        _graph = graph;
        _origin = origin;
        _iterations = iterations;
    }

    public void Run()
    {
        _solutions = new List<Route>();

        for (int i = 0; i < _iterations; i++)
        {
            _solutions.Add(Generate());
        }

        _solutions = _solutions.OrderBy(x => x.TotalDistance).ToList();
    }

    private Route Generate()
    {
        Route solution = new Route();

        solution.Nodes.Add(_origin);
        Node current = _origin;

        for (int i = 0; i < _graph.Count - 1; i++)
        {
            Node next;

            do
            {
                next = NextNode(current);
            } while (solution.Nodes.Contains(next));

            solution.Nodes.Add(next);
            solution.TotalDistance += current.Ways.First(x => x.Node.City == next.City).Distance;

            current = next;
        }

        solution.Nodes.Add(_origin);
        solution.TotalDistance += current.Ways.First(x => x.Node.City == _origin.City).Distance;

        return solution;
    }

    private Node NextNode(Node current)
    {
        int nextNode = new Random().Next(0, _graph.Count - 1);
        return current.Ways[nextNode].Node;
    }

    public string GetAllRoutes()
    {
        string result = "";

        foreach (Route route in _solutions)
        {
            foreach (Node node in route.Nodes)
            {
                result += $"{node.City},";
            }

            result += $" {route.TotalDistance}\n";
        }

        return result;
    }
}
