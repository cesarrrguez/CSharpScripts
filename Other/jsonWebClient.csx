#r "nuget: Newtonsoft.Json, 12.0.3"

using System.Net;
using Newtonsoft.Json;

const string url = "https://jsonplaceholder.typicode.com/posts";
var client = new WebClient();
var json = client.DownloadString(url);
dynamic posts = JsonConvert.DeserializeObject(json);

foreach (var post in posts)
{
    Console.WriteLine(post.id + ": " + post.title);
}
