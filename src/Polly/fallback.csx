#r "nuget: Polly, 7.2.2"

using Polly;

Retry();

public void Retry()
{
    int retries = 1;

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
            WriteLine(retries);
            retries++;
            throw new Exception();
        });

    WriteLine("Finish");
}
