using System.Collections;

var stack = new Stack();

// Push 1, 2, 3
WriteLine("Push: 1, 2, 3");
stack.Push("1");
stack.Push("2");
stack.Push("3");

// Peek
WriteLine($"\nPeek: {stack.Peek()}\n");

// Pop
while (stack.Count > 0)
{
    WriteLine($"Pop: {stack.Pop()}");
}
