using System.Threading;

bool exit;

// One thread
// var thread = new Thread(ThreadMessage);
// thread.Start();

// MultiThread
for (var i = 0; i < 8; i++)
{
    var thread = new Thread(MultiThreadMessage);
    //thread.IsBackground = true; // Ends when main ends
    thread.Start(i);
}

int i;
while (!exit)
{
    Thread.Sleep(100);
    WriteLine("Main - {0}", i++);

    if (i == 10)
        exit = true;
}

public void ThreadMessage()
{
    var i = 0;

    while (!exit)
    {
        Thread.Sleep(100);
        WriteLine("\t\tThread X - {0}", i++);
    }
}

public void MultiThreadMessage(object obj)
{
    var i = 0;
    var thread = Convert.ToInt32(obj);
    var tabs = new string(Enumerable.Repeat('\t', 2 * (thread + 1)).ToArray());

    while (!exit)
    {
        Thread.Sleep(100);
        WriteLine("{0}Thread {1} - {2}", tabs, thread, i++);
    }
}
