#load "entities.csx"

var heap = new Heap<int>(13);

// Add
for (int i = 1; i < 8; i++)
{
    heap.Add(i);
}
heap.Print();

// Remove min
for (int i = 1; i < 7; i++)
{
    Console.WriteLine($"Remove min: {heap.RemoveMin()}");

    heap.Print();
}