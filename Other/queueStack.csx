// Queue is a FIFO (first in first out) data structure
var queue = new Queue<string>();

queue.Enqueue("1");
queue.Enqueue("2");
queue.Enqueue("3");

Console.WriteLine("Queue:");
while (queue.Count > 0)
{
    Console.WriteLine(queue.Dequeue());
}

// Stack is a LIFO (last in first out) data structure
var stack = new Stack<string>();

stack.Push("1");
stack.Push("2");
stack.Push("3");

Console.WriteLine("\nStack:");
while (stack.Count > 0)
{
    Console.WriteLine(stack.Pop());
}
