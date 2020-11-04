await foreach (var number in GenerateSequence())
{
    WriteLine($"Number {number} received");
}

public async IAsyncEnumerable<int> GenerateSequence()
{
    for (int i = 0; i < 10; i++)
    {
        WriteLine($"Before add number {i}");
        await Task.Delay(1000).ConfigureAwait(false);
        yield return i;
        WriteLine($"After add number {i}\n");
    }
}
