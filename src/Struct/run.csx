// Struct
// ---------------------------------------------------
// A struct stores its data in its type.
// It is not allocated separately on the managed heap.
// Struct reside on the stack.
// ---------------------------------------------------
// Struct: Stack ->  By value      -> Quickly access
// Class:  Heap  ->  By reference 
// ---------------------------------------------------
// Use struct when:
// - You have a lot of data in memory
// - Inmutable objects once created
// - Instance size less than 16 bytes
// - Don´t need convert to object (boxed)
// - Performance needed
// ---------------------------------------------------

#load "entities.csx"

Point point = new Point(1200, 250);
Point.IncreasePoint(point, 100);

Console.WriteLine(point);
