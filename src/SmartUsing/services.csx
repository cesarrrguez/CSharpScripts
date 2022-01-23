#load "interfaces.csx"
#load "utils.csx"

using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;

public class PostService : IPostService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<PostService> _logger;

    public PostService(IHttpClientFactory httpClientFactory, ILogger<PostService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<Post> GetPostAsync(int number)
    {
        var url = $"/posts/{number}";
        var client = _httpClientFactory.CreateClient("API");

        using var _ = _logger.TimedOperation("Post retrieval for {0}", number);

        var response = await client.GetAsync(url);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<Post>();
    }
}
