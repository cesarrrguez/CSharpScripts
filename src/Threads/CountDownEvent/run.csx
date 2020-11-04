// Count Down Event
// ------------------------------------------------------------------------------------
// Represents a synchronization primitive that is signaled when its count reaches zero.
// ------------------------------------------------------------------------------------

using System.Threading;

var counter = new CountdownEvent(5);
bool exit;

var thread1 = new Thread(Work);
var thread2 = new Thread(Work);

thread1.Start();
thread2.Start();

// We wait main thread
counter.Wait();

WriteLine("Counter is 0");
exit = true;

public void Work()
{
    var rnd = new Random();

    while (!exit)
    {
        var i = rnd.Next(0, 10);

        if (i < 3)
        {
            // Decrement counter
            counter.Signal();
        }

        WriteLine(i);

        Thread.Sleep(1000);
    }
}
