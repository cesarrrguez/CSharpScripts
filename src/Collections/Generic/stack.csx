// Stack
// ----------------------------------------
// LIFO (last in first out) data structure.
// ----------------------------------------

using System.Collections.Generic;

var stack = new Stack<int>();

// Push 1, 2, 3
WriteLine("Push: 1, 2, 3");
stack.Push(1);
stack.Push(2);
stack.Push(3);

// Peek
WriteLine($"\nPeek: {stack.Peek()}\n");

// Pop
while (stack.Count > 0)
{
    WriteLine($"Pop: {stack.Pop()}");
}
