using System.Net.Http;

var accumulator = Accumulator(Request);

Parallel.For(1, 101, (_) => accumulator());
Read();

Func<int> Accumulator(Action<int> function)
{
    var counter = 0;
    return () =>
    {
        counter++;
        function(counter);
        return counter;
    };
}

async void Request(int i)
{
    var client = new HttpClient();
    var response = await client.GetAsync("https://google.com");
    WriteLine($"Request number {i} - {response.StatusCode}");
}
