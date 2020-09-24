using System.Threading;

public static class Utils
{
    public static void SequentialLoop(int iterations)
    {
        for (var i = 0; i < iterations; i++)
        {
            WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
            Thread.Sleep(10);
        }
    }

    public static void ParallelLoop(int iterations)
    {
        Parallel.For(0, iterations, i =>
        {
            WriteLine("Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
            Thread.Sleep(10);
        });
    }

    public static void BeginSection(int number, string title)
    {
        WriteLine($"{number}) {title}");
        WriteLine(new string(Enumerable.Repeat('-', 67).ToArray()));
    }
}
