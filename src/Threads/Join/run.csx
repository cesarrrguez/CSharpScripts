using System.Threading;

var thread = new Thread(Message);
thread.Start();

thread.Join();

for (var i = 0; i < 10; i++)
{
    WriteLine("Main -> {0}", i);
}

public void Message()
{
    for (var i = 0; i < 10; i++)
    {
        WriteLine("Thread {0} -> {1}", Thread.CurrentThread.ManagedThreadId, i);
    }
}
