#load "utils.csx"

var separator = new string(Enumerable.Repeat('-', 30).ToArray());

// GET async
WriteLine("GET async:");
WriteLine(separator);
var posts = await Utils.GetPosts().ConfigureAwait(false);
foreach (var post in posts)
{
    WriteLine($"{post}\n");
}

// POST async
WriteLine("POST async:");
WriteLine(separator);
var post = new Post()
{
    UserId = 50,
    Title = "Hello everybody!",
    Body = "Hello! how are you?",
};
post = await Utils.AddPost(post).ConfigureAwait(false);
WriteLine($"{post}");

// PUT async
WriteLine("\nPUT async:");
WriteLine(separator);
post.Id = 99;
post = await Utils.EditPost(post).ConfigureAwait(false);
WriteLine($"{post}");

// DELETE async
WriteLine("\nDELETE async:");
WriteLine(separator);
var deleted = await Utils.DeletePost(99).ConfigureAwait(false);
WriteLine($"Deleted: {deleted.ToYesNoString()}");
