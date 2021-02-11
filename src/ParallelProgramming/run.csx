using System.Net.Http;

var tasks = new List<Task>();

for (var i = 0; i < 100; i++)
{
    var item = i + 1; // Modified closure

    tasks.Add(Task.Run(
        async () =>
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/todos/{item}");
            var result = await response.Content.ReadAsStringAsync();
            WriteLine(result);
        }
    ));
}

Task.WaitAll(tasks.ToArray());
