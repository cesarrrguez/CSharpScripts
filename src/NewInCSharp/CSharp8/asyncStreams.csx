await foreach (var number in GenerateSequence())
{
    WriteLine($"Number {number} received");
}

public async IAsyncEnumerable<int> GenerateSequence()
{
    for (var i = 0; i < 10; i++)
    {
        WriteLine($"Before add number {i}");
        await Task.FromResult(0);
        yield return i;
        WriteLine($"After add number {i}\n");
    }
}
