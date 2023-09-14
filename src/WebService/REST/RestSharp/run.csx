#load "../../../../packages.csx"

#load "services.csx"
#load "utils.csx"

var separator = new string(Enumerable.Repeat('-', 30).ToArray());

var postService = new PostService();

// GET
WriteLine("GET:");
WriteLine(separator);
postService.GetPosts();

// POST
WriteLine("\nPOST:");
WriteLine(separator);
var post = new Post()
{
    UserId = 50,
    Title = "Hello everybody!",
    Body = "Hello! how are you?",
};
postService.AddPost(post);

// PUT
WriteLine("\nPUT:");
WriteLine(separator);
post.Id = 99;
postService.EditPost(post);

// DELETE
WriteLine("\nDELETE:");
WriteLine(separator);
postService.DeletePost(99);
