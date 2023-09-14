#load "../../../../packages.csx"

#load "services.csx"
#load "data.csx"
#load "utils.csx"
#load "enums.csx"

var postService = new ActionService<Post>(Action.Posts);
var post = await postService.GetAsync(1);
WriteLine(post.Title);

var photoService = new ActionService<Photo>(Action.Photos);
var photoRepository = new ActionRepository<Photo>(Action.Photos);
var photo = await photoService.GetAsync(1);
await photoRepository.SaveAsync(photo.Url);
