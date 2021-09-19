Task task = Task.Run(() =>
{
    Task.Delay(1000);
    WriteLine("Hello");
});

task.Wait();

WriteLine("World");
