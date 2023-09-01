#load "entities.csx"

using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

public class PostService
{
    // GET
    public async Task<List<Post>> GetPostsAsync()
    {
        const string url = "https://jsonplaceholder.typicode.com/posts";
        using var client = new HttpClient();

        using var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Post>>();
        }

        throw new Exception((int)response.StatusCode + " - " + response.StatusCode.ToString());
    }

    // POST
    public async Task<Post> AddPostAsync(Post post)
    {
        const string url = "https://jsonplaceholder.typicode.com/posts";
        using var client = new HttpClient();

        var data = JsonSerializer.Serialize(post);
        var content = new StringContent(data, Encoding.UTF8, "application/json");

        using var response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Post>();
        }

        throw new Exception((int)response.StatusCode + " - " + response.StatusCode.ToString());
    }

    // PUT
    public async Task<Post> EditPostAsync(Post post)
    {
        var url = $"https://jsonplaceholder.typicode.com/posts/{post.Id}";
        using var client = new HttpClient();

        var data = JsonSerializer.Serialize(post);
        var content = new StringContent(data, Encoding.UTF8, "application/json");

        using var response = await client.PutAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Post>();
        }

        throw new Exception((int)response.StatusCode + " - " + response.StatusCode.ToString());
    }

    // DELETE
    public async Task<bool> DeleteAsync(int postId)
    {
        var url = $"https://jsonplaceholder.typicode.com/posts/{postId}";
        using var client = new HttpClient();

        using var response = await client.DeleteAsync(url);

        return response.IsSuccessStatusCode;
    }
}
