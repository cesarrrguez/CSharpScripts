using System.Threading;

bool exit;
int counter;
var control = new object();

var thread1 = new Thread(Increment);
thread1.Start();

var thread2 = new Thread(Increment);
thread2.Start();

while (!exit)
{
    if (counter > 10) exit = true;
}

public void Increment()
{
    while (!exit)
    {
        Monitor.Enter(control);
        try
        {
            counter++;
            Write(Thread.CurrentThread.ManagedThreadId);
            WriteLine(" -> {0}", counter);

            Thread.Sleep(1000);
        }
        finally
        {
            Monitor.Exit(control);
        }
    }
}
