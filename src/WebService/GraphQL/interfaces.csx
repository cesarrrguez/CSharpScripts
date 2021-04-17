#load "entities.csx"

public interface IGraphQLSettings
{
    string EndPointUrl { get; set; }
}

public interface IPostService : IDisposable
{
    Task<List<Post>> GetAllPostsAsync(PostOptionsInput postOptionsInput);
    Task<Post> GetPostAsync(int id);
    Task<Post> CreatePostAsync(PostInput postToCreate);
    Task<Post> UpdatePostAsync(int id, PostInput postToUpdate);
    Task<bool> DeletePostAsync(int id);
}

public interface IPostController : IDisposable
{
    void GetAllPosts(PostOptionsInput postOptionsInput);
    void GetPost(int id);
    void CreatePost(PostInput postToCreate);
    void UpdatePost(int id, PostInput postToUpdate);
    void DeletePost(int id);
}
