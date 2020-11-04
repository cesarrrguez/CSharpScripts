using System.Threading;

var iterations = 10;
var stopwatch = new Stopwatch();

// Sequential For Loop
WriteLine("Sequential For Loop:");
SequentialLoop(iterations);

// Parallel For Loop
WriteLine("Parallel For Loop:");
ParallelLoop(iterations);

public void SequentialLoop(int iterations)
{
    stopwatch.Start();

    for (var i = 0; i < iterations; i++)
    {
        WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
        Thread.Sleep(10);
    }

    stopwatch.Stop();
    WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds\n");
}

public void ParallelLoop(int iterations)
{
    stopwatch.Restart();

    Parallel.For(0, iterations, i =>
    {
        WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
        Thread.Sleep(10);
    });

    stopwatch.Stop();
    WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds");
}
