#load "entities.csx"

using System.Net.Http;
using System.Text.Json;

public static class Utils
{
    public static async Task<List<Post>> GetPosts()
    {
        var url = "https://jsonplaceholder.typicode.com/posts";
        var client = new HttpClient();

        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

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
