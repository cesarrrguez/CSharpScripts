var tree = BuildTree();

WriteLine($"The common ancestor is {tree.GetCommonAncestor(10, 6).Value}");
WriteLine($"The common ancestor is {tree.GetCommonAncestor(9, 7).Value}");
WriteLine($"The common ancestor is {tree.GetCommonAncestor(7, 2).Value}");

public Tree<int> BuildTree()
{
    var tree = new Tree<int>();

    var node_1 = tree.Add(null, 1);
    var node_2 = tree.Add(node_1, 2);
    var node_3 = tree.Add(node_1, 3);
    var node_4 = tree.Add(node_1, 4);
    var node_5 = tree.Add(node_2, 5);
    var node_6 = tree.Add(node_2, 6);
    var node_7 = tree.Add(node_3, 7);
    var node_8 = tree.Add(node_6, 8);
    var node_9 = tree.Add(node_6, 9);
    var node_10 = tree.Add(node_5, 10);

    return tree;
}

public class Tree<T>
{
    public Node<T> Root { get; set; }

    public Node<T> Add(Node<T> parent, T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));

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
        if (node == null) throw new ArgumentNullException(nameof(node));

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

    public Node<T> GetCommonAncestor(T valueA, T valueB)
    {
        if (valueA == null) throw new ArgumentNullException(nameof(valueA));
        if (valueB == null) throw new ArgumentNullException(nameof(valueB));

        var nodeA = Find(Root, valueA);
        var nodeB = Find(Root, valueB);

        if (nodeA == null) throw new ArgumentException(nameof(valueA));
        if (nodeB == null) throw new ArgumentException(nameof(valueB));

        // Base case
        if (nodeA.Parent.Value.Equals(nodeB.Parent.Value)) return nodeA.Parent;

        var pathNodeA = GetPath(nodeA);
        var pathNodeB = GetPath(nodeB);

        Node<T> ancestor = Root;

        for (var i = 0; i < Math.Min(pathNodeA.Count, pathNodeB.Count) - 1; i++)
        {
            if (pathNodeA[i].Value.Equals(pathNodeB[i].Value))
            {
                ancestor = pathNodeA[i];
            }
            else
            {
                break;
            }
        }

        return ancestor;
    }

    public List<Node<T>> GetPath(Node<T> node)
    {
        if (node == null) throw new ArgumentNullException(nameof(node));

        var path = new List<Node<T>>
        {
            node
        };

        while ((node = node.Parent) != null)
        {
            path.Add(node);
        }

        path.Reverse();

        return path;
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Parent { get; set; }
    public ICollection<Node<T>> Children { get; }

    public Node(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));

        Value = value;
        Children = new List<Node<T>>();
    }
}
