var names = new List<string> { "bob", "alice", "john", "jane" };

var stopwatch = new Stopwatch();

stopwatch.Start();

var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 3 };
await Parallel.ForEachAsync(names, parallelOptions, async (name, _) => await IsValid(name));

stopwatch.Stop();

WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

async Task IsValid(string name)
{
    await Validation1(name);
    await Validation2(name);
    await Validation3(name);
    await Validation4(name);
}

public async Task Validation1(string name)
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    WriteLine($"{nameof(Validation1)} - {name}");
}

public async Task Validation2(string name)
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    WriteLine($"{nameof(Validation2)} - {name}");
}

public async Task Validation3(string name)
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    WriteLine($"{nameof(Validation3)} - {name}");
}

public async Task Validation4(string name)
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    WriteLine($"{nameof(Validation4)} - {name}");
}
