#load "entities.csx"

public interface IPostService
{
    Task<Post> GetPost(int id);
}
