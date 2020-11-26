using System.Threading;

var rnd = new Random();

var thread = new Thread(Work);
thread.Start();

int i;
while (i < 1000)
{
    if (rnd.Next(100) < 2)
    {
        thread.Interrupt();
    }
    Thread.Sleep(50);
    i++;
}

public void Work()
{
    var i = 0;
    var sum = 0;

    try
    {
        while (i < 1000)
        {
            sum += i;
            Thread.Sleep(100);
            WriteLine(i);
            i++;
        }
    }
    catch (ThreadInterruptedException)
    {
        WriteLine("Work interrupted");
    }
}
