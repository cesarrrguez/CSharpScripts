#load "interfaces.csx"
#load "entities.csx"

using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

public class PostService : IPostService
{
    private readonly MemoryCache _cache;

    public PostService()
    {
        _cache = new MemoryCache(new MemoryCacheOptions());
    }

    public async Task<Post> GetPost(int id)
    {
        // Check if exists
        if (!_cache.TryGetValue(id, out Post post))
        {
            post = await GetPostFromHttp(id).ConfigureAwait(false);
            _cache.Set(id, post);

            return post;
        }

        return post;
    }

    private async Task<Post> GetPostFromHttp(int id)
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}").ConfigureAwait(false);
    }
}
