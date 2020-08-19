// Stack
// ----------------------------------------
// LIFO (last in first out) data structure.
// ----------------------------------------

public class Stack<T>
{
    public Node<T> Top { get; set; }

    public void Push(T value)
    {
        var node = new Node<T>(value);
        node.Next = Top;
        Top = node;
    }

    public T Pop()
    {
        if (Top == null) throw new InvalidOperationException("Stack empty");

        var value = Top.Value;

        Top = Top.Next;

        return value;
    }

    public T Peek()
    {
        if (Top == null) throw new InvalidOperationException("Stack empty");

        return Top.Value;
    }

    public int Count()
    {
        var node = Top;
        var count = 0;

        while (node != null)
        {
            count++;

            node = node.Next;
        }

        return count;
    }

    public void Clear()
    {
        Top = null;
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
