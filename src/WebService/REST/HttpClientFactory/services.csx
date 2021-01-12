#load "interfaces.csx"

using System.Net.Http;
using System.Text.Json;

public class PostService : IPostService
{
    private readonly IHttpClientFactory _clientFactory;

    public PostService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
    }

    public async Task<Post> GetPost(int number)
    {
        var url = $"/posts/{number}";
        var client = _clientFactory.CreateClient("API");

        using var response = await client.GetAsync(url).ConfigureAwait(false);

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
}
