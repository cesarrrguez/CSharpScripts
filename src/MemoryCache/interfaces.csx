#load "entities.csx"

public interface IPostService
{
    Task<Post> GetAsync(int id);
}
