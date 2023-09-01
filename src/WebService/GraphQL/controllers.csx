#load "interfaces.csx"
#load "entities.csx"
#load "utils.csx"

public class PostController : IPostController
{
    private readonly IPostService _postService;
    private readonly string _separator = new string(Enumerable.Repeat('-', 15).ToArray());

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    public async Task GetAllAsync(PostOptionsInput postOptionsInput)
    {
        if (postOptionsInput == null) throw new ArgumentNullException(nameof(postOptionsInput));

        WriteLine("\nGet all Posts:");
        WriteLine(_separator);

        var posts = await _postService.GetAllAsync(postOptionsInput);

        if (posts?.Count > 0)
        {
            posts.ForEach(post => WriteLine($"{post}\n"));
        }
        else
        {
            WriteLine("No posts");
        }
    }

    public async Task GetAsync(int id)
    {
        WriteLine("\nGet a Post:");
        WriteLine(_separator);

        var post = await _postService.GetAsync(id);
        if (post == null) throw new ArgumentException(nameof(id));

        WriteLine(post);
    }

    public async Task CreateAsync(PostInput postToCreate)
    {
        if (postToCreate == null) throw new ArgumentNullException(nameof(postToCreate));

        WriteLine("\nCreate a Post:");
        WriteLine(_separator);

        var post = await _postService.CreateAsync(postToCreate);

        WriteLine(post);
    }

    public async Task UpdateAsync(int id, PostInput postToUpdate)
    {
        if (postToUpdate == null) throw new ArgumentNullException(nameof(postToUpdate));

        WriteLine("\nUpdate a Post:");
        WriteLine(_separator);

        var post = await _postService.GetAsync(id);
        if (post == null) throw new ArgumentException(nameof(id));

        post = await _postService.UpdateAsync(id, postToUpdate);

        WriteLine(post);
    }

    public async Task DeleteAsync(int id)
    {
        WriteLine("\nDelete a Post:");
        WriteLine(_separator);

        var post = await _postService.GetAsync(id);
        if (post == null) throw new ArgumentException(nameof(id));

        var response = await _postService.DeleteAsync(id);

        WriteLine(response.ToYesNoString());
    }

    public void Dispose()
    {
        _postService.Dispose();
        GC.SuppressFinalize(this);
    }
}
