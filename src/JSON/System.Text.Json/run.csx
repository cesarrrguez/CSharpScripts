#load "entities.csx"
#load "utils.csx"

using System.Text.Json;

WriteLine("Processing users ... \n");

// Read
var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "users.json");
var json = File.ReadAllText(path);
var users = JsonSerializer.Deserialize<User[]>(json);
var orderedUsers = users.OrderBy(x => x.Name);

foreach (var user in orderedUsers)
{
    WriteLine($"User: {user.Name} - {user.Email}");
}

// Write
path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "user.json");
json = JsonSerializer.Serialize(users.OrderBy(x => x.Name).First());
File.WriteAllText(path, json);
