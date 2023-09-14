#load "entities.csx"

public interface IGraphQLSettings
{
    string EndPointUrl { get; set; }
}

public interface IPostService
{
    Task<List<Post>> GetAllAsync(PostOptionsInput postOptionsInput);
    Task<Post> GetAsync(int id);
    Task<Post> CreateAsync(PostInput postToCreate);
    Task<Post> UpdateAsync(int id, PostInput postToUpdate);
    Task<bool> DeleteAsync(int id);
}

public interface IPostController
{
    Task GetAllAsync(PostOptionsInput postOptionsInput);
    Task GetAsync(int id);
    Task CreateAsync(PostInput postToCreate);
    Task UpdateAsync(int id, PostInput postToUpdate);
    Task DeleteAsync(int id);
}
