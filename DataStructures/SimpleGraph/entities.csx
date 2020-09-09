public class Node<T>
{
    public T Value { get; set; }
    public List<Node<T>> Nodes { get; set; }

    public Node(T value)
    {
        Value = value;
        Nodes = new List<Node<T>>();
    }

    public string GetPath(string tab = "")
    {
        var sb = new StringBuilder();

        // Append current node value
        sb.Append(tab).Append(this).Append('\n');

        // Loop children
        foreach (var node in Nodes)
        {
            sb.Append(node.GetPath($"{tab}\t"));
        }

        return sb.ToString();
    }

    public override string ToString()
    {
        return $"({Value})";
    }
}
