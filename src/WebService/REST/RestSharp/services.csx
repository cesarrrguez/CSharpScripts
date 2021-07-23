#load "entities.csx"

using System.Net.Http;
using System.Text.Json;

using RestSharp;

public class PostService
{
    // GET
    public void GetPosts()
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest("posts", Method.GET);
        var response = client.Execute(request);
        WriteLine(response.Content);
    }

    // POST
    public void AddPost(Post post)
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest("posts", Method.POST);

        var data = JsonSerializer.Serialize(post);
        var content = new StringContent(data, Encoding.UTF8, "application/json");
        request.AddParameter("data", content);

        var response = client.Execute(request);
        WriteLine(response.Content);
    }

    // PUT
    public void EditPost(Post post)
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest($"posts/{post.Id}", Method.PUT);

        var data = JsonSerializer.Serialize(post);
        var content = new StringContent(data, Encoding.UTF8, "application/json");
        request.AddParameter("data", content);

        var response = client.Execute(request);
        WriteLine(response.Content);
    }

    // DELETE
    public void DeletePost(int postId)
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest($"posts/{postId}", Method.DELETE);
        var response = client.Execute(request);
        WriteLine(response.Content);
    }
}
