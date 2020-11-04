using System.Collections.Generic;

var values = new LinkedList<int>();

// Add last
values.AddLast(3);
values.AddLast(5);
values.AddLast(7);
values.AddLast(9);
values.AddLast(11);
values.AddLast(15);

// Print
Console.WriteLine($"List: {String.Join(", ", values)}");

// Nodes
 Console.Write("Nodes: ");
for (LinkedListNode<int> node = values.First; node != null; node = node.Next)
{
    int value = node.Value;
    Console.Write($"({value})");

    if (node.Next != null)
    {
        Console.Write(" -> ");
    }
    else
    {
        Console.WriteLine();
    }
}

// Contains
Console.WriteLine($"Contains 5: {values.Contains(5)}");

// Remove node
values.Remove(values.First);
Console.WriteLine($"Remove node: {String.Join(", ", values)}");

// Remove value
values.Remove(5);
Console.WriteLine($"Remove value: {String.Join(", ", values)}");

// Remove first
values.RemoveFirst();
Console.WriteLine($"Remove first: {String.Join(", ", values)}");

// Remove last
values.RemoveLast();
Console.WriteLine($"Remove last: {String.Join(", ", values)}");

// Clear
values.Clear();
Console.WriteLine($"Clear: {String.Join(", ", values)}");
