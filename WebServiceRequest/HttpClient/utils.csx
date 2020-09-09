#load "entities.csx"

using System.Net.Http;
using System.Text.Json;

public static class Utils
{
    public static async Task<List<Post>> GetPosts()
    {
        const string url = "https://jsonplaceholder.typicode.com/posts";
        var client = new HttpClient();

        var response = await client.GetAsync(url).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<List<Post>>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        return null;
    }
}
