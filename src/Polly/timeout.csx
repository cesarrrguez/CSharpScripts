#r "nuget: Polly, 7.2.2"

using Polly;
using Polly.Timeout;

Timeout();

public void Timeout()
{
    Policy
    .Timeout(1, TimeoutStrategy.Pessimistic, onTimeout: (_, _, _) => WriteLine("Timeout"))
    .ExecuteAndCapture(() => System.Threading.Thread.Sleep(2000));

    WriteLine("Finish");
}
