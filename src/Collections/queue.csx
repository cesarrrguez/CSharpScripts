// Queue
// -----------------------------------------
// FIFO (first in first out) data structure.
// -----------------------------------------

using System.Collections;

var queue = new Queue();

// Enqueue 1, 2, 3
WriteLine("Enqueue: 1, 2, 3");
queue.Enqueue("1");
queue.Enqueue("2");
queue.Enqueue("3");

// Peek
WriteLine($"\nPeek: {queue.Peek()}\n");

// Dequeue
while (queue.Count > 0)
{
    WriteLine($"Dequeue: {queue.Dequeue()}");
}
