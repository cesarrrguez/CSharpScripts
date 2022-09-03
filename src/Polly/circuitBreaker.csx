#r "nuget: Polly, 7.2.2"

using Polly;
using Polly.Timeout;
using Polly.CircuitBreaker;

using System.Threading;

CircuitBreak().Wait();

public async Task CircuitBreak()
{
    AsyncCircuitBreakerPolicy result = Policy
        .Handle<Exception>()
        .CircuitBreakerAsync(
            exceptionsAllowedBeforeBreaking: 10,
            durationOfBreak: TimeSpan.FromSeconds(5),
            onBreak: (ex, _) => WriteLine("Circuit breaker opened because of {0}", ex.Message),
            onReset: () => WriteLine("Circuit breaker reset"),
            onHalfOpen: () => WriteLine("Circuit breaker half-open")
        );

    while (true)
    {
        await result.ExecuteAndCaptureAsync(async () =>
        {
            WriteLine("Calling API...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            throw new Exception("API failed.");
        });
    }
}
