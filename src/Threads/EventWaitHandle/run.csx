// Event Wait Handle
// ------------------------------------------
// Represents a thread synchronization event.
// ------------------------------------------

using System.Threading;

EventWaitHandle handler = new AutoResetEvent(false);

var thread = new Thread(Counter);
thread.Start();

WriteLine("To sleep");
Thread.Sleep(3000);

// Continue
handler.Set();

WriteLine("Main ends");

public void Counter()
{
    WriteLine("Counter starts");

    // Wait
    handler.WaitOne();

    WriteLine("Wait ends");

    for (var i = 0; i < 10; i++)
    {
        WriteLine(i);
    }
}
