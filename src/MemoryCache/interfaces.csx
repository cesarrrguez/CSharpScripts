#load "entities.csx"

public interface IPostService
{
    Task<Post> GetPostAsync(int id);
}
