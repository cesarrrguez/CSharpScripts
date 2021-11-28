public class Node
{
    public string City { get; set; }
    public List<Way> Ways { get; set; }

    public Node()
    {
        Ways = new List<Way>();
    }
}

public struct Way
{
    public Node Node { get; set; }
    public int Distance { get; set; }
}

public class Route
{
    public List<Node> Nodes { get; set; }
    public int TotalDistance { get; set; }

    public Route()
    {
        Nodes = new List<Node>();
        TotalDistance = 0;
    }
}
