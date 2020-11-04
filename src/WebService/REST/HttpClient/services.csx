#load "entities.csx"

using System.Net.Http;
using System.Text.Json;

public class PostService
{
    // GET
    public async Task<List<Post>> GetPosts()
    {
        const string url = "https://jsonplaceholder.typicode.com/posts";
        using var client = new HttpClient();

        using var response = await client.GetAsync(url).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<List<Post>>(result,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        throw new Exception((int)response.StatusCode + " - " + response.StatusCode.ToString());
    }

    // POST
    public async Task<Post> AddPost(Post post)
    {
        const string url = "https://jsonplaceholder.typicode.com/posts";
        using var client = new HttpClient();

        var data = JsonSerializer.Serialize<Post>(post);
        var content = new StringContent(data, Encoding.UTF8, "application/json");

        using var response = await client.PostAsync(url, content).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<Post>(result,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        throw new Exception((int)response.StatusCode + " - " + response.StatusCode.ToString());
    }

    // PUT
    public async Task<Post> EditPost(Post post)
    {
        string url = $"https://jsonplaceholder.typicode.com/posts/{post.Id}";
        using var client = new HttpClient();

        var data = JsonSerializer.Serialize<Post>(post);
        var content = new StringContent(data, Encoding.UTF8, "application/json");

        using var response = await client.PutAsync(url, content).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<Post>(result,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        throw new Exception((int)response.StatusCode + " - " + response.StatusCode.ToString());
    }

    // DELETE
    public async Task<bool> DeletePost(int postId)
    {
        string url = $"https://jsonplaceholder.typicode.com/posts/{postId}";
        using var client = new HttpClient();

        using var response = await client.DeleteAsync(url).ConfigureAwait(false);

        return response.IsSuccessStatusCode;
    }
}
