#r "nuget: Polly, 7.2.2"

using Polly;
using Polly.Timeout;

Timeout().Wait();

public async Task Timeout()
{
    await Policy
        .TimeoutAsync(
            seconds: 1,
            TimeoutStrategy.Pessimistic,
            onTimeoutAsync: async (_, _, _) =>
            {
                WriteLine("Timeout");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        )
        .ExecuteAndCaptureAsync(async () => await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false))
        .ConfigureAwait(false);

    WriteLine("Finish");
}
