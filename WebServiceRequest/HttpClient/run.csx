#load "utils.csx"

var posts = await Utils.GetPosts();

foreach (var post in posts)
{
    Console.WriteLine($"{post}\n");
}
