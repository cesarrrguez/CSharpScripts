Task[] tasks = new Task[3];
tasks[0] = Task.Run(Request1);
tasks[1] = Task.Run(Request2);
tasks[2] = Task.Run(Request1);

WriteLine("Waiting");

Task.WaitAll(tasks);

WriteLine("End");

public void Request1()
{
    Task.Delay(TimeSpan.FromSeconds(2));
    WriteLine("Request 1");
}

public void Request2()
{
    Task.Delay(TimeSpan.FromSeconds(2));
    WriteLine("Request 2");
}
