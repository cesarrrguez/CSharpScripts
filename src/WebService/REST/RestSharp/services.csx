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
        var request = new RestRequest("posts", Method.Get);
        var response = client.Execute(request);
        WriteLine(response.Content);
    }

    // POST
    public void AddPost(Post post)
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest("posts", Method.Post);

        var data = JsonSerializer.Serialize(post);
        request.AddParameter("data", data);

        var response = client.Execute(request);
        WriteLine(response.Content);
    }

    // PUT
    public void EditPost(Post post)
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest($"posts/{post.Id}", Method.Put);

        var data = JsonSerializer.Serialize(post);
        request.AddParameter("data", data);

        var response = client.Execute(request);
        WriteLine(response.Content);
    }

    // DELETE
    public void DeletePost(int postId)
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest($"posts/{postId}", Method.Delete);
        var response = client.Execute(request);
        WriteLine(response.Content);
    }
}
