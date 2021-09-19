using System.Threading;

var source = new CancellationTokenSource();
var token = source.Token;

Task[] tasks = new Task[3];
tasks[0] = Task.Run(Request1, token);
tasks[1] = Task.Run(Request2);
tasks[2] = Task.Run(Request1, token);

source.Cancel();

try
{
    Task.WaitAll(tasks);
}
catch (System.Exception)
{
    WriteLine();
}

foreach (var task in tasks)
{
    WriteLine($"{task.Id} {task.Status}");
}

WriteLine("End");

public void Request1()
{
    Task.Delay(2000);
    WriteLine("Request 1");
}

public void Request2()
{
    Task.Delay(2000);
    WriteLine("Request 2");
}
