#load "../../../../packages.csx"

#load "utils.csx"

using System.Net.Http;
using System.Net.Http.Formatting;

var post = new Post();
await post.GetInfoAsync(1);

var photo = new Photo();
await photo.SaveAsync(1);

public class Post
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public async Task GetInfoAsync(int id)
    {
        var url = "https://jsonplaceholder.typicode.com/posts/" + id;
        using var client = new HttpClient();
        using var response = await client.GetAsync(url);
        var post = await response.Content.ReadAsAsync<Post>();
        WriteLine(post.Title);
    }
}

public class Photo
{
    public int AlbumId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string ThumbnailUrl { get; set; }

    public async Task SaveAsync(int id)
    {
        var url = "https://jsonplaceholder.typicode.com/photos/" + id;
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        var photo = await response.Content.ReadAsAsync<Photo>();

        var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files/photos.txt");
        using var stream = File.Create(path);
        byte[] buffer = new UTF8Encoding(true).GetBytes(photo.Url);
        await stream.WriteAsync(buffer, 0, buffer.Length);
    }
}
