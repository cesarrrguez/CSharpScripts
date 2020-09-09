#load "utils.csx"

var posts = await Utils.GetPosts().ConfigureAwait(false);

foreach (var post in posts)
{
    Console.WriteLine($"{post}\n");
}
