using System.Threading;

bool exit1;
int counter1;

bool exit2;
int counter2;

var thread1 = new Thread(Increment1);
thread1.Priority = ThreadPriority.Lowest;
thread1.Start();

var thread2 = new Thread(Increment2);
thread2.Priority = ThreadPriority.Highest;
thread2.Start();

public void Increment1()
{
    while (!exit1)
    {
        counter1++;

        WriteLine("{0} - {1}", Thread.CurrentThread.ManagedThreadId, counter1);

        if (counter1 > 100)
        {
            exit1 = true;
            exit2 = true;
        }
    }
}

public void Increment2()
{
    while (!exit2)
    {
        counter2++;

        WriteLine("\t\t{0} - {1}", Thread.CurrentThread.ManagedThreadId, counter2);

        if (counter2 > 100)
        {
            exit1 = true;
            exit2 = true;
        }
    }
}
