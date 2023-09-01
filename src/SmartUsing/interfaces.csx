#load "records.csx"

public interface IPostService
{
    Task<Post> GetAsync(int number);
}
