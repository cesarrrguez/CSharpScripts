#load "utils.csx"

using System.Threading;

var iterations = 10;
var stopwatch = new Stopwatch();

// Sequential For Loop
Utils.BeginSection(1, "Sequential For Loop");
stopwatch.Start();
Utils.SequentialLoop(iterations);
stopwatch.Stop();
WriteLine($"\nTime elapsed: {stopwatch.ElapsedMilliseconds} milliseconds\n");

// Parallel For Loop
Utils.BeginSection(2, "Parallel For Loop");
stopwatch.Restart();
Utils.ParallelLoop(iterations);
stopwatch.Stop();
WriteLine($"\nTime elapsed: {stopwatch.ElapsedMilliseconds} milliseconds");
