public class Post
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}

public class Photo
{
    public int AlbumId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string ThumbnailUrl { get; set; }
}
