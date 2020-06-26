public class Node<T>
{
    public T Value { get; set; }
    public List<Node<T>> NodeList { get; set; }

    public Node(T value)
    {
        Value = value;
        NodeList = new List<Node<T>>();
    }
}
