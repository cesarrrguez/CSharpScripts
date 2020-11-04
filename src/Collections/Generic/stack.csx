// Stack
// ----------------------------------------
// LIFO (last in first out) data structure.
// ----------------------------------------

using System.Collections.Generic;

var stack = new Stack<int>();

// Push 1, 2, 3
Console.WriteLine("Push: 1, 2, 3");
stack.Push(1);
stack.Push(2);
stack.Push(3);

// Peek
Console.WriteLine($"\nPeek: {stack.Peek()}\n");

// Pop
while (stack.Count > 0)
{
    Console.WriteLine($"Pop: {stack.Pop()}");
}
