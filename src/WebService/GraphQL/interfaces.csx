#load "entities.csx"

public interface IGraphQLSettings
{
    string EndPointUrl { get; set; }
}

public interface IPostService : IDisposable
{
    Task<List<Post>> GetAllPosts(PostOptionsInput postOptionsInput);
    Task<Post> GetPost(int id);
    Task<Post> CreatePost(PostInput postToCreate);
    Task<Post> UpdatePost(int id, PostInput postToUpdate);
    Task<bool> DeletePost(int id);
}

public interface IPostController : IDisposable
{
    void GetAllPosts(PostOptionsInput postOptionsInput);
    void GetPost(int id);
    void CreatePost(PostInput postToCreate);
    void UpdatePost(int id, PostInput postToUpdate);
    void DeletePost(int id);
}
