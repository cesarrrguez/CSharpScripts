// Deadlock
// ----------------------------------------------------------
//  State in which each thread is waiting for another thread.
// ----------------------------------------------------------

using System.Threading;

var control1 = new object();
var control2 = new object();

WriteLine("Start");

var thread1 = new Thread(Method1);
thread1.Start();

var thread2 = new Thread(Method2);
thread2.Start();

WriteLine("End");

public void Method1()
{
    lock (control1)
    {
        Thread.Sleep(500);
        lock (control2)
        {
            WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}

public void Method2()
{
    lock (control2)
    {
        Thread.Sleep(500);
        lock (control1)
        {
            WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
