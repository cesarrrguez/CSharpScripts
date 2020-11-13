using System.Diagnostics;
using System.Threading;

// Create new stopwatch
Stopwatch stopwatch = new Stopwatch();

// Begin timing
stopwatch.Start();

// Do something
for (int i = 0; i < 1000; i++)
{
    Thread.Sleep(1);
}

// Stop timing
stopwatch.Stop();

// Write result
WriteLine($"Time elapsed: {stopwatch.Elapsed}");
