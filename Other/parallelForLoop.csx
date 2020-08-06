using System.Threading;

var iterations = 10;
var stopwatch = new Stopwatch();
void BeginSection(int number, string title)
{
    Console.WriteLine($"{number}) {title}");
    Console.WriteLine(new string(Enumerable.Repeat('-', 67).ToArray()));
}

// Sequential For Loop
BeginSection(1, "Sequential For Loop");
stopwatch.Start();
for (var i = 0; i < iterations; i++)
{
    Console.WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
    Thread.Sleep(10);
}
stopwatch.Stop();
Console.WriteLine($"\nTime elapsed: {stopwatch.ElapsedMilliseconds} milliseconds\n");

// Parallel For Loop
BeginSection(2, "Parallel For Loop");
stopwatch.Restart();
Parallel.For(0, iterations, i =>
{
    Console.WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
    Thread.Sleep(10);
});
stopwatch.Stop();
Console.WriteLine($"\nTime elapsed: {stopwatch.ElapsedMilliseconds} milliseconds");
