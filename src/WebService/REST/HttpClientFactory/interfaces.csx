#load "records.csx"

public interface IPostService
{
    Task<Post> GetPostAsync(int number);
}
