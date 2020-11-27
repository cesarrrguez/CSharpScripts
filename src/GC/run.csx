#load "entities.csx"

// Get heap bytes quantity
long heapBytes = GC.GetTotalMemory(false);
WriteLine("Heap use {0} bytes", heapBytes);

// Get max generation. It is + 1 because starts at 0
long maxGeneration = GC.MaxGeneration + 1;
WriteLine("There are {0} generations", maxGeneration);

// Create new instance of test class
var test = new Test(5);

// Get heap bytes quantity after instance
heapBytes = GC.GetTotalMemory(false);
WriteLine("Heap use {0} bytes", heapBytes);

// Get instance generation
long instanceGeneration = GC.GetGeneration(test);
WriteLine("Instance generation is {0}", instanceGeneration);

// Force garbage collection
GC.Collect();
GC.WaitForPendingFinalizers();

// Force garbage collection concrete instance
GC.Collect(0);
GC.WaitForPendingFinalizers();
