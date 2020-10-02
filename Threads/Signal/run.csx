using System.Threading;

bool exit;
int counter;
var signal = new ManualResetEvent(false);

var thread = new Thread(Increment);
thread.Start();

int i;
while (i < 80)
{
    Thread.Sleep(100);
    WriteLine("Main - {0}", i++);

    // if (thread.ThreadState != 0)
    //     WriteLine("\t\tThread - Waiting");
}

// Thread can continue
signal.Set();

public void Increment()
{
    while (!exit)
    {
        counter++;

        Thread.Sleep(100);
        WriteLine("\t\tThread - {0}", counter);

        // Pause thread until signal set
        if (counter == 25)
        {
            signal.WaitOne();
        }

        if (counter > 50)
        {
            exit = true;
            signal.Dispose();
        }
    }
}
