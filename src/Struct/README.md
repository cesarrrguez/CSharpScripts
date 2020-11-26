# Struct

A struct stores its data in its type.

It is not allocated separately on the managed heap. Struct reside on the stack.

## When to use a Struct

- You have a lot of data in memory.
- Inmutable objects once created.
- Instance size less than 16 bytes.
- Don´t need convert to object (boxed).
- Performance needed.
