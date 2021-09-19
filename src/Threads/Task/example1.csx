using System.Threading;

bool exit;
int counter;

var task = Task.Factory.StartNew(Increment);
task.Wait(TimeSpan.FromMilliseconds(1000));

public void Increment()
{
    while (!exit)
    {
        counter++;

        WriteLine("{0} - {1}", Thread.CurrentThread.ManagedThreadId, counter);

        if (counter > 100)
        {
            exit = true;
        }
    }
}
