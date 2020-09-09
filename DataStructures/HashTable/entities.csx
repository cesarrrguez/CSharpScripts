public class HashTable<T1, T2>
{
    public Node<T1, T2> Head { get; set; }

    public void Add(T1 key, T2 value)
    {
        Head = new Node<T1, T2>(key, value)
        {
            Next = Head
        };
    }

    public Node<T1, T2> FindByKey(T1 key)
    {
        var node = Head;

        while (node != null)
        {
            if (node.Key.Equals(key))
                return node;

            node = node.Next;
        }

        return null;
    }

    public Node<T1, T2> FindByValue(T2 value)
    {
        var node = Head;

        while (node != null)
        {
            if (node.Value.Equals(value))
                return node;

            node = node.Next;
        }

        return null;
    }

    public bool ContainsKey(T1 key)
    {
        return FindByKey(key) != null;
    }

    public bool ContainsValue(T2 value)
    {
        return FindByValue(value) != null;
    }

    public void Remove(T1 key)
    {
        var node = FindByKey(key);

        if (node == null) return;

        if (node == Head)
        {
            Head = node.Next;
            return;
        }

        var nodeBefore = GetBeforeNode(node);
        nodeBefore.Next = node.Next;
    }

    private Node<T1, T2> GetBeforeNode(Node<T1, T2> nextNode)
    {
        var node = Head;

        while (node != null)
        {
            if (node.Next == nextNode)
                return node;

            node = node.Next;
        }

        return null;
    }

    public int Count()
    {
        var node = Head;
        var count = 0;

        while (node != null)
        {
            count++;

            node = node.Next;
        }

        return count;
    }

    public List<T2> ToList()
    {
        var result = new List<T2>();
        var node = Head;

        while (node != null)
        {
            result.Add(node.Value);

            node = node.Next;
        }

        return result;
    }

    public T2 this[T1 key]
    {
        get
        {
            return FindByKey(key).Value;
        }

        set
        {
            var node = FindByKey(key);

            if (node != null)
            {
                node.Value = value;
            }
        }
    }

    public void Clear()
    {
        Head = null;
    }
}

public class Node<T1, T2>
{
    public T1 Key { get; set; }
    public T2 Value { get; set; }
    public Node<T1, T2> Next { get; set; }

    public Node(T1 key, T2 value)
    {
        Key = key;
        Value = value;
        Next = null;
    }

    public override string ToString()
    {
        return $"[{Key}, {Value}]";
    }
}
