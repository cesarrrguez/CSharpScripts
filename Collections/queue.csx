// Queue is a FIFO (first in first out) data structure
// ---------------------------------------------------

using System.Collections;

var queue = new Queue();

// Enqueue 1, 2, 3
Console.WriteLine("Enqueue: 1, 2, 3");
queue.Enqueue("1");
queue.Enqueue("2");
queue.Enqueue("3");

// Peek
Console.WriteLine($"\nPeek: {queue.Peek()}\n");

// Dequeue
while (queue.Count > 0)
{
    Console.WriteLine($"Pop: {queue.Dequeue()}");
}
