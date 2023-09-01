#load "interfaces.csx"

using System.Net.Http;
using System.Net.Http.Json;

public class PostService : IPostService
{
    private readonly IHttpClientFactory _clientFactory;

    public PostService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<Post> GetAsync(int number)
    {
        var url = $"/posts/{number}";
        var client = _clientFactory.CreateClient("API");

        using var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Post>();
        }

        throw new Exception((int)response.StatusCode + " - " + response.StatusCode.ToString());
    }
}
