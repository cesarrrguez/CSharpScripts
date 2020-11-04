#load "interfaces.csx"
#load "entities.csx"
#load "utils.csx"

public class PostController : IPostController
{
    private readonly IPostService _postService;
    private readonly string _separator = new string(Enumerable.Repeat('-', 15).ToArray());

    public PostController(IPostService postService)
    {
        _postService = postService ?? throw new ArgumentNullException(nameof(postService));
    }

    public void GetAllPosts(PostOptionsInput postOptionsInput)
    {
        if (postOptionsInput == null) throw new ArgumentNullException(nameof(postOptionsInput));

        WriteLine("\nGet all Posts:");
        WriteLine(_separator);

        var posts = _postService.GetAllPosts(postOptionsInput).Result;

        if (posts?.Count > 0)
            posts.ForEach(post => WriteLine($"{post}\n"));
        else
            WriteLine("No posts");
    }

    public void GetPost(int id)
    {
        WriteLine("\nGet a Post:");
        WriteLine(_separator);

        var post = _postService.GetPost(id).Result;
        if (post == null) throw new ArgumentException(nameof(id));

        WriteLine(post);
    }

    public void CreatePost(PostInput postToCreate)
    {
        if (postToCreate == null) throw new ArgumentNullException(nameof(postToCreate));

        WriteLine("\nCreate a Post:");
        WriteLine(_separator);

        var post = _postService.CreatePost(postToCreate).Result;

        WriteLine(post);
    }

    public void UpdatePost(int id, PostInput postToUpdate)
    {
        if (postToUpdate == null) throw new ArgumentNullException(nameof(postToUpdate));

        WriteLine("\nUpdate a Post:");
        WriteLine(_separator);

        var post = _postService.GetPost(id).Result;
        if (post == null) throw new ArgumentException(nameof(id));

        post = _postService.UpdatePost(id, postToUpdate).Result;

        WriteLine(post);
    }

    public void DeletePost(int id)
    {
        WriteLine("\nDelete a Post:");
        WriteLine(_separator);

        var post = _postService.GetPost(id).Result;
        if (post == null) throw new ArgumentException(nameof(id));

        var response = _postService.DeletePost(id).Result;

        WriteLine(response.ToYesNoString());
    }

    public void Dispose()
    {
        _postService.Dispose();
        GC.SuppressFinalize(this);
    }
}
