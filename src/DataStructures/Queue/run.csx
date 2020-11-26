#load "entities.csx"

var queue = new Queue<string>();

// Enqueue 1, 2, 3
WriteLine("Enqueue: 1, 2, 3");
queue.Enqueue("1");
queue.Enqueue("2");
queue.Enqueue("3");

// Peek
WriteLine($"\nPeek: {queue.Peek()}\n");

// Dequeue
while (queue.Count() > 0)
{
    WriteLine($"Dequeue: {queue.Dequeue()}");
}
