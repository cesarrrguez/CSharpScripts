#load "services.csx"
#load "utils.csx"

var separator = new string(Enumerable.Repeat('-', 30).ToArray());

var postService = new PostService();

// GET
WriteLine("GET:");
WriteLine(separator);
var posts = await postService.GetPosts().ConfigureAwait(false);
foreach (var post in posts)
{
    WriteLine($"{post}\n");
}

// POST
WriteLine("POST:");
WriteLine(separator);
var post = new Post()
{
    UserId = 50,
    Title = "Hello everybody!",
    Body = "Hello! how are you?",
};
post = await postService.AddPost(post).ConfigureAwait(false);
WriteLine($"{post}");

// PUT
WriteLine("\nPUT:");
WriteLine(separator);
post.Id = 99;
post = await postService.EditPost(post).ConfigureAwait(false);
WriteLine($"{post}");

// DELETE
WriteLine("\nDELETE:");
WriteLine(separator);
var deleted = await postService.DeletePost(99).ConfigureAwait(false);
WriteLine($"Deleted: {deleted.ToYesNoString()}");
