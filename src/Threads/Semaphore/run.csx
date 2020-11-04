// Semaphore
// -------------------------------------------------------------------------------------------
//  Limits the number of threads that can access a resource or pool of resources concurrently.
// -------------------------------------------------------------------------------------------

using System.Threading;

var semaphore = new Semaphore(3, 3);
int counter;

for (int i = 0; i < 8; i++)
{
    new Thread(Method).Start(i);
}

public void Method(object obj)
{
    var thread = Convert.ToInt32(obj);
    WriteLine("Thread {0} on method", thread);

    semaphore.WaitOne();

    counter++;
    WriteLine("Number of threads on critical section: {0}", counter);

    WriteLine("Thread {0} start critical section", thread);

    var rnd = new Random();
    Thread.Sleep(rnd.Next(1, 5) * 1000);

    WriteLine("Thread {0} ends critical section", thread);

    semaphore.Release();
    counter--;
    WriteLine("Number of threads on critical section: {0}", counter);
}
