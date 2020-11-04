public class SingleLinkedList<T>
{
    public Node<T> Head { get; set; }

    public void AddFirst(T value)
    {
        Head = new Node<T>(value)
        {
            Next = Head
        };
    }

    public void AddLast(T value)
    {
        var node = new Node<T>(value);

        if (Head == null)
        {
            Head = node;
            return;
        }

        var lastNode = GetLastNode();
        lastNode.Next = node;
    }

    public void AddAfter(Node<T> previousNode, T value)
    {
        if (previousNode == null) return;

        previousNode.Next = new Node<T>(value)
        {
            Next = previousNode.Next
        };
    }

    public void AddBefore(Node<T> nextNode, T value)
    {
        if (nextNode == null) return;

        if (nextNode == Head)
        {
            AddFirst(value);
            return;
        }

        var node = new Node<T>(value)
        {
            Next = nextNode
        };

        var beforeNode = GetBeforeNode(nextNode);
        beforeNode.Next = node;
    }

    public void AddAfter(T previousValue, T value)
    {
        var node = Find(previousValue);
        AddAfter(node, value);
    }

    public void AddBefore(T nextValue, T value)
    {
        var node = Find(nextValue);
        AddBefore(node, value);
    }

    public Node<T> GetLastNode()
    {
        var node = Head;

        if (node == null) return null;

        while (node.Next != null)
        {
            node = node.Next;
        }

        return node;
    }

    public Node<T> GetBeforeNode(Node<T> nextNode)
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

    public Node<T> Find(T value)
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

    public Node<T> FindByIndex(int index)
    {
        var node = Head;
        var i = -1;

        while (node != null)
        {
            i++;

            if (i == index)
                return node;

            node = node.Next;
        }

        return null;
    }

    public Node<T> FindPrevious(T value)
    {
        var node = Head;

        while (node != null)
        {
            if (node.Next == null) return null;

            if (node.Next.Value.Equals(value))
                return node;

            node = node.Next;
        }

        return null;
    }

    public int FindIndex(T value)
    {
        var node = Head;
        var index = -1;

        while (node != null)
        {
            index++;

            if (node.Value.Equals(value))
                return index;

            node = node.Next;
        }

        return -1;
    }

    public void Remove(T value)
    {
        var node = Find(value);

        if (node == null) return;

        if (node == Head)
        {
            Head = node.Next;
            return;
        }

        var nodeBefore = GetBeforeNode(node);
        nodeBefore.Next = node.Next;
    }

    public void Reverse()
    {
        Node<T> previous = null;
        Node<T> current = Head;
        Node<T> temp;

        while (current != null)
        {
            temp = current.Next;
            current.Next = previous;
            previous = current;
            current = temp;
        }

        Head = previous;
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

    public List<T> ToList()
    {
        var result = new List<T>();
        var node = Head;

        while (node != null)
        {
            result.Add(node.Value);

            node = node.Next;
        }

        return result;
    }

    public T this[int index]
    {
        get
        {
            return FindByIndex(index).Value;
        }

        set
        {
            var node = FindByIndex(index);

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

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
    }

    public override string ToString()
    {
        return $"[{Value}]";
    }
}
