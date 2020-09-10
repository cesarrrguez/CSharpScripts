#load "entities.csx"

using System.Net.Http;
using System.Text.Json;

public static class Utils
{
    // GET async
    public static async Task<List<Post>> GetPosts()
    {
        const string url = "https://jsonplaceholder.typicode.com/posts";
        var client = new HttpClient();

        var response = await client.GetAsync(url).ConfigureAwait(false);

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

        return null;
    }

    // POST async
    public static async Task<Post> AddPost(Post post)
    {
        const string url = "https://jsonplaceholder.typicode.com/posts";
        var client = new HttpClient();

        var data = JsonSerializer.Serialize<Post>(post);
        var content = new StringContent(data, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content).ConfigureAwait(false);

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

        return null;
    }

    // PUT async
    public static async Task<Post> EditPost(Post post)
    {
        string url = $"https://jsonplaceholder.typicode.com/posts/{post.Id}";
        var client = new HttpClient();

        var data = JsonSerializer.Serialize<Post>(post);
        var content = new StringContent(data, Encoding.UTF8, "application/json");

        var response = await client.PutAsync(url, content).ConfigureAwait(false);

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

        return null;
    }

    // DELETE async
    public static async Task<bool> DeletePost(int postId)
    {
        string url = $"https://jsonplaceholder.typicode.com/posts/{postId}";
        var client = new HttpClient();

        var response = await client.DeleteAsync(url).ConfigureAwait(false);

        return response.IsSuccessStatusCode;
    }
}

// Extensions
// ------------------------------------------------------------

public static string ToYesNoString(this bool value)
{
    return value ? "Yes" : "No";
}
