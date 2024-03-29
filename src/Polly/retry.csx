#load "../../packages.csx"

using Polly;

await Retry();

public async Task Retry()
{
    int retries = 1;

    PolicyResult result = await Policy
        .Handle<Exception>()
        .WaitAndRetryAsync(
            retryCount: 3,
            sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
            onRetry: (ex, time) =>
            {
                WriteLine($"Exception '{ex.GetType().Name}' with message '{ex.Message}' detected on attempt {retries} of 3.");
                WriteLine($"Waiting {time.TotalMilliseconds}ms until next retry...\n");
                retries++;
            })
        .ExecuteAndCaptureAsync(async () =>
        {
            WriteLine("Calling API...");
            await Task.FromResult(0);
            throw new Exception("API failed.");
        });

    WriteLine($"Retry operation completed with {result.Outcome}");
}
