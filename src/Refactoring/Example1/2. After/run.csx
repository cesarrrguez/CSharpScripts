#load "services.csx"
#load "data.csx"
#load "utils.csx"
#load "enums.csx"

#r "nuget: Microsoft.AspNet.WebApi.Client, 5.2.7"
#r "nuget: Flurl.Http, 2.4.2"

var postService = new ActionService<Post>(Action.Posts);
var post = await postService.GetAsync(1);
WriteLine(post.Title);

var photoService = new ActionService<Photo>(Action.Photos);
var photoRepository = new ActionRepository<Photo>(Action.Photos);
var photo = await photoService.GetAsync(1);
await photoRepository.SaveAsync(photo.Url);
