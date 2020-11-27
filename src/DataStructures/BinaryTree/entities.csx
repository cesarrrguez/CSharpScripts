public class BinaryTree<T>
{
    public Node<T> Root { get; set; }

    public Node<T> Add(Node<T> node, T value)
    {
        if (node == null)
        {
            node = new Node<T>(value);

            if (Root == null)
            {
                Root = node;
            }

            return node;
        }

        if (Comparer<T>.Default.Compare(value, node.Value) < 0)
        {
            node.Left = Add(node.Left, value);
        }

        if (Comparer<T>.Default.Compare(value, node.Value) > 0)
        {
            node.Right = Add(node.Right, value);
        }

        return node;
    }

    public string TraversePreOrder(Node<T> node)
    {
        if (node == null) return null;

        var sb = new StringBuilder();

        sb.Append(node).Append(' ');
        sb.Append(TraversePreOrder(node.Left));
        sb.Append(TraversePreOrder(node.Right));

        return sb.ToString();
    }

    public string TraverseInOrder(Node<T> node)
    {
        if (node == null) return null;

        var sb = new StringBuilder();

        sb.Append(TraverseInOrder(node.Left));
        sb.Append(node).Append(' ');
        sb.Append(TraverseInOrder(node.Right));

        return sb.ToString();
    }

    public string TraversePostOrder(Node<T> node)
    {
        if (node == null) return null;

        var sb = new StringBuilder();

        sb.Append(TraversePostOrder(node.Left));
        sb.Append(TraversePostOrder(node.Right));
        sb.Append(node).Append(' ');

        return sb.ToString();
    }

    public int Depth(Node<T> node)
    {
        return node == null ? 0 : Math.Max(Depth(node.Left), Depth(node.Right)) + 1;
    }

    public Node<T> Min(Node<T> node)
    {
        if (node == null) throw new ArgumentNullException(nameof(node));

        var min = node;

        while (node.Left != null)
        {
            min = node.Left;
            node = node.Left;
        }

        return min;
    }

    public Node<T> Max(Node<T> node)
    {
        if (node == null) throw new ArgumentNullException(nameof(node));

        var max = node;

        while (node.Right != null)
        {
            max = node.Right;
            node = node.Right;
        }

        return max;
    }

    public Node<T> Find(Node<T> node, T value)
    {
        if (node == null) return null;

        if (Comparer<T>.Default.Compare(value, node.Value) == 0)
        {
            return node;
        }

        if (Comparer<T>.Default.Compare(value, node.Value) < 0)
        {
            return Find(node.Left, value);
        }

        if (Comparer<T>.Default.Compare(value, node.Value) > 0)
        {
            return Find(node.Right, value);
        }

        return null;
    }

    public Node<T> Remove(Node<T> node, T value)
    {
        if (node == null) return node;

        if (Comparer<T>.Default.Compare(value, node.Value) < 0)
        {
            node.Left = Remove(node.Left, value);
        }
        else if (Comparer<T>.Default.Compare(value, node.Value) > 0)
        {
            node.Right = Remove(node.Right, value);
        }
        else
        {
            // Node with only one child or no child  
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            // Node with two children: Get the InOrder successor (smallest in the right subtree)  
            node.Value = Min(node.Right).Value;

            // Delete the InOrder successor  
            node.Right = Remove(node.Right, node.Value);
        }

        return node;
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }

    public Node(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }

    public override string ToString() => $"[{Value}]";
}
