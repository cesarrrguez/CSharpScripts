#load "services.csx"

#r "nuget: Microsoft.Extensions.Caching.Memory, 3.1.0"
var service = new PostService();

// Post 1
var post1 = await service.GetPostAsync(1).ConfigureAwait(false);
WriteLine(post1);
WriteLine();

var post1_second_call = await service.GetPostAsync(1).ConfigureAwait(false);
WriteLine(post1_second_call);
WriteLine();

// Post 2
var post2 = await service.GetPostAsync(2).ConfigureAwait(false);
WriteLine(post2);
WriteLine();

var post2_second_call = await service.GetPostAsync(2).ConfigureAwait(false);
WriteLine(post2_second_call);
