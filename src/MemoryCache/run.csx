#load "services.csx"

#r "nuget: Microsoft.Extensions.Caching.Memory, 3.1.0"
var service = new PostService();

// Post 1
var post1 = service.GetPostAsync(1);
WriteLine(post1.Result);
WriteLine();

var post1_second_call = service.GetPostAsync(1);
WriteLine(post1_second_call.Result);
WriteLine();

// Post 2
var post2 = service.GetPostAsync(2);
WriteLine(post2.Result);
WriteLine();

var post2_second_call = service.GetPostAsync(2);
WriteLine(post2_second_call.Result);
