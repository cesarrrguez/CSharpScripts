#load "entities.csx"

public static void GetNodePath<T>(this Node<T> node, string tab = "")
{
    // Check null node
    if (node == null) return;

    // Print current node value
    Console.WriteLine($"{tab}{node.Value}");

    // Loop node list
    foreach (var n in node.NodeList)
    {
        GetNodePath<T>(n, $"{tab}\t");
    }
}
