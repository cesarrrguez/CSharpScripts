// Mutex
// -----------------------------------------------------------------------------------
// A synchronization primitive that can also be used for interprocess synchronization.
// -----------------------------------------------------------------------------------

using System.Threading;

using (var mutex = new Mutex(false, "Test"))
{
    if (!mutex.WaitOne(TimeSpan.FromMilliseconds(1000), false))
    {
        WriteLine("Other instance running");
        Thread.Sleep(1000);

        return;
    }

    Run();
}

public void Run()
{
    var i = 0;

    while (i < 1000)
    {
        WriteLine(i++);
    }
}
