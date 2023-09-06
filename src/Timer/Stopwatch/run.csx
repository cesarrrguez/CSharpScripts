// Begin timing
var stopwatch = Stopwatch.StartNew();

// Do something
await Task.Delay(Random.Shared.Next(5, 30));

// Stop timing
stopwatch.Stop();

// Write result
WriteLine($"Took: {stopwatch.ElapsedMilliseconds} ms");
