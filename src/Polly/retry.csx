#r "nuget: Polly, 7.2.2"

using Polly;

Retry();

public void Retry()
{
    int counter = 0;

    try
    {
        Policy
       .Handle<Exception>()
       .Retry(3)
       .Execute(() =>
       {
           WriteLine(counter);
           counter++;
           throw new Exception();
       });
    }
    catch (Exception)
    {
        WriteLine("Retry exceed");
    }

    WriteLine("Finish");
}
