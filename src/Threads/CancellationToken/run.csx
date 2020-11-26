using System.Threading;

bool exit;
var counter = 0;
var rnd = new Random();

var cancellation = new CancellationTokenSource();

var thread = new Thread(() => Work(cancellation.Token));
thread.Start();

int i;
while (i < 1000 && !exit)
{
    if (rnd.Next(100) < 2)
    {
        cancellation.Cancel();
    }

    Thread.Sleep(50);
    i++;
}

public void Work(CancellationToken cancellationToken)
{
    while (!exit)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            counter++;
            WriteLine("Working {0}", counter);

            Thread.Sleep(50);

            if (counter > 10000)
                exit = true;
        }
        catch (OperationCanceledException)
        {
            WriteLine("It was canceled");
            exit = true;
        }
    }
}
