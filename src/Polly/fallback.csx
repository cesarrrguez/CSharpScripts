#r "nuget: Polly, 7.2.2"

using Polly;

Retry();

public void Retry()
{
    int counter = 0;

    Policy
    .Handle<Exception>()
    .Fallback(_ => WriteLine("Retry exceed"))
    .Wrap(
        Policy
        .Handle<Exception>()
        .Retry(3)
    )
    .Execute(() =>
    {
        WriteLine(counter);
        counter++;
        throw new Exception();
    });

    WriteLine("Finish");
}
