// Lock
// ----------------------------------------------------------
// Ensures that one thread does not enter a critical section 
// while another thread is in the critical section of code.
// ----------------------------------------------------------

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
    if (counter > 10)
        exit = true;
}

public void Increment()
{
    while (!exit)
    {
        lock (control)
        {
            counter++;
            Write(Thread.CurrentThread.ManagedThreadId);
            WriteLine(" -> {0}", counter);

            Thread.Sleep(1000);
        }
    }
}
