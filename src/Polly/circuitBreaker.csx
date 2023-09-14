#load "../../packages.csx"

using Polly;
using Polly.Timeout;
using Polly.CircuitBreaker;

using System.Threading;

await CircuitBreak();

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
            await Task.FromResult(0);
            throw new Exception("API failed.");
        });
    }
}
