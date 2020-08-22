public class Queue<T>
{
    public Node<T> Head { get; set; }

    public void Enqueue(T value)
    {
        var node = new Node<T>(value);

        if (Head == null)
        {
            Head = node;
            return;
        }

        var tail = Head;
        while (tail.Next != null)
        {
            tail = tail.Next;
        }

        tail.Next = node;
    }

    public T Dequeue()
    {
        if (Head == null) throw new InvalidOperationException("Queue empty");

        var value = Head.Value;

        Head = Head.Next;

        return value;
    }

    public T Peek()
    {
        if (Head == null) throw new InvalidOperationException("Queue empty");

        return Head.Value;
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
