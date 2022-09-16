Task task = Task.Run(() =>
{
    Task.Delay(TimeSpan.FromSeconds(1));
    WriteLine("Hello");
});

await task;

WriteLine("World");
