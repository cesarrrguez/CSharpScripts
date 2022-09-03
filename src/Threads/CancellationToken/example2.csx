using System.Threading;

var cancellationTokenSource = new CancellationTokenSource();
await ExampleWithLoop(cancellationTokenSource);

public async Task ExampleWithLoop(CancellationTokenSource cancellationTokenSource)
{
    await Task.Run(() =>
    {
        var key = ReadKey();
        if (key.Key == ConsoleKey.C)
        {
            cancellationTokenSource.Cancel();
            WriteLine("Cancelled the task");
        }
    });

    while (!cancellationTokenSource.Token.IsCancellationRequested)
    {
        WriteLine("Doing some work for 3 seconds");
        await Task.Delay(TimeSpan.FromSeconds(3));
    }

    WriteLine("Token was cancelled and we exited the loop");

    cancellationTokenSource.Dispose();
}
