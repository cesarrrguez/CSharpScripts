#load "interfaces.csx"
#load "entities.csx"

using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

public class PostService : IPostService
{
    private readonly IMemoryCache _memoryCache;

    public PostService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task<Post> GetAsync(int id)
    {
        // Check if exists
        if (!_memoryCache.TryGetValue(id, out Post post))
        {
            post = await GetPostFromHttpAsync(id);
            _memoryCache.Set(id, post);

            return post;
        }

        return post;
    }

    private async Task<Post> GetPostFromHttpAsync(int id)
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");
    }
}
