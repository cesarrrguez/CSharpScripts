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
    Task GetAllPostsAsync(PostOptionsInput postOptionsInput);
    Task GetPostAsync(int id);
    Task CreatePostAsync(PostInput postToCreate);
    Task UpdatePostAsync(int id, PostInput postToUpdate);
    Task DeletePostAsync(int id);
}
