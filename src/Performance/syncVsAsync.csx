using System.Net.Http;
using System.Threading;

SyncMethod();
AsyncMethod();

public void SyncMethod()
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();

    var client = new HttpClient();

    var response1 = client.GetAsync("http://www.google.es").Result;
    var response2 = client.GetAsync("http://www.github.com").Result;
    var response3 = client.GetAsync("http://www.gitlab.com").Result;

    Thread.Sleep(1000);

    stopWatch.Stop();

    WriteLine(stopWatch.ElapsedMilliseconds);
}

public async void AsyncMethod()
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();

    var client = new HttpClient();

    var response1Task = client.GetAsync("http://www.google.es");
    var response2Task = client.GetAsync("http://www.github.com");
    var response3Task = client.GetAsync("http://www.gitlab.com");

    Thread.Sleep(1000);

    var response1 = await response1Task;
    var response2 = await response2Task;
    var response3 = await response3Task;

    stopWatch.Stop();

    WriteLine(stopWatch.ElapsedMilliseconds);
}
