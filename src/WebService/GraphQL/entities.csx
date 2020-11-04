public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public override string ToString() => $"Id: {Id}\nTitle: {Title}\nBody: {Body}";
}

public class PostCollection
{
    public Post[] Data { get; set; }
    public PostCollectionMeta Meta { get; set; }
}

public class PostCollectionMeta
{
    public int TotalCount { get; set; }
}

public class PostInput
{
    public string Title { get; set; }
    public string Body { get; set; }

    public override string ToString() => $"Title: {Title}\nBody: {Body}";
}

public class PostOptionsInput
{
    public PostOptionsInputPagination Paginate { get; set; }
}

public class PostOptionsInputPagination
{
    public int Page { get; set; }
    public int Limit { get; set; }
}

public class ResponsePostCollectionType
{
    public PostCollection Posts { get; set; }
}

public class ResponsePostType
{
    public Post Post { get; set; }
}

public class ResponseCreatePostType
{
    public Post CreatePost { get; set; }
}

public class ResponseUpdatePostType
{
    public Post UpdatePost { get; set; }
}

public class ResponseDeletePostType
{
    public bool DeletePost { get; set; }
}
