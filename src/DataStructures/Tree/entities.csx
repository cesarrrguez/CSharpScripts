public class Tree<T>
{
    public Node<T> Root { get; set; }

    public Node<T> Add(Node<T> parent, T value)
    {
        var node = new Node<T>(value)
        {
            Parent = parent
        };

        if (parent == null)
        {
            Root = node;
        }
        else
        {
            parent.Children.Add(node);
        }

        return node;
    }

    public Node<T> Find(Node<T> node, T value)
    {
        // Check null node
        if (node == null) return null;

        // Check current node value
        if (node.Value.Equals(value))
            return node;

        // Loop children
        foreach (var child in node.Children)
        {
            var target = Find(child, value);

            if (target != null)
                return target;
        }

        return null;
    }

    public string GetPath(Node<T> node, string tab = "")
    {
        // Check null node
        if (node == null) return null;

        var sb = new StringBuilder();

        // Append current node value
        sb.Append(tab).Append(node).Append('\n');

        // Loop children
        foreach (var child in node.Children)
        {
            sb.Append(GetPath(child, $"{tab}\t"));
        }

        return sb.ToString();
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Parent { get; set; }
    public ICollection<Node<T>> Children { get; }

    public Node(T value)
    {
        Value = value;
        Children = new List<Node<T>>();
    }

    public override string ToString() => $"({Value})";
}
