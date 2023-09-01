#load "services.csx"
#load "utils.csx"

var separator = new string(Enumerable.Repeat('-', 30).ToArray());

var postService = new PostService();

// GET
WriteLine("GET:");
WriteLine(separator);
var posts = await postService.GetPostsAsync();
foreach (var post in posts)
{
    WriteLine($"{post}\n");
}

// POST
WriteLine("POST:");
WriteLine(separator);
var post = new Post
{
    UserId = 50,
    Title = "Hello everybody!",
    Body = "Hello! how are you?",
};
post = await postService.AddPostAsync(post);
WriteLine($"{post}");

// PUT
WriteLine("\nPUT:");
WriteLine(separator);
post.Id = 99;
post = await postService.EditPostAsync(post);
WriteLine($"{post}");

// DELETE
WriteLine("\nDELETE:");
WriteLine(separator);
var deleted = await postService.DeleteAsync(99);
WriteLine($"Deleted: {deleted.ToYesNoString()}");
