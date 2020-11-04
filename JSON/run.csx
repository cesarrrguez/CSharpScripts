#load "entities.csx"
#load "utils.csx"

#r "nuget: Newtonsoft.Json, 12.0.3"

using Newtonsoft.Json;

Console.WriteLine("Processing users ... \n");

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "users.json");
var json = File.ReadAllText(path);
var users = JsonConvert.DeserializeObject<User[]>(json);
var orderedUsers = users.OrderBy(x => x.Name);

foreach (var user in orderedUsers)
{
    Console.WriteLine($"User: {user.Name} - {user.Email}");
}
