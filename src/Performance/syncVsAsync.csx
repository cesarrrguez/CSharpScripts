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

    WriteLine($"Elapsed time: {stopWatch.ElapsedMilliseconds} ms");
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

    await Task.WhenAll(response1Task, response2Task, response3Task);

    var response1 = response1Task.Result;
    var response2 = response2Task.Result;
    var response3 = response3Task.Result;

    stopWatch.Stop();

    WriteLine($"Elapsed time: {stopWatch.ElapsedMilliseconds} ms");
}
