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
WriteLine($"List: {String.Join(", ", values)}");

// Nodes
Write("Nodes: ");
for (LinkedListNode<int> node = values.First; node != null; node = node.Next)
{
    int value = node.Value;
    Write($"({value})");

    if (node.Next != null)
    {
        Write(" -> ");
    }
    else
    {
        WriteLine();
    }
}

// Contains
WriteLine($"Contains 5: {values.Contains(5)}");

// Remove node
values.Remove(values.First);
WriteLine($"Remove node: {String.Join(", ", values)}");

// Remove value
values.Remove(5);
WriteLine($"Remove value: {String.Join(", ", values)}");

// Remove first
values.RemoveFirst();
WriteLine($"Remove first: {String.Join(", ", values)}");

// Remove last
values.RemoveLast();
WriteLine($"Remove last: {String.Join(", ", values)}");

// Clear
values.Clear();
WriteLine($"Clear: {String.Join(", ", values)}");
