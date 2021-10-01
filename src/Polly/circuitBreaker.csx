#r "nuget: Polly, 7.2.2"

using Polly;
using Polly.Timeout;

CircuitBreak();

public void CircuitBreak()
{
    var pol = Policy
          .Handle<Exception>()
          .CircuitBreaker(
          exceptionsAllowedBeforeBreaking: 10,
          durationOfBreak: TimeSpan.FromSeconds(5),
          onBreak: (_, __) => WriteLine("Break"),
          onReset: () => WriteLine("Reset"));

    while (true)
    {
        pol.ExecuteAndCapture(() =>
        {
            System.Threading.Thread.Sleep(100);
            WriteLine("Error");
            throw new Exception();
        });
    }
}
