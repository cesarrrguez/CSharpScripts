#load "entities.csx"
#r "nuget: Newtonsoft.Json, 12.0.3"

using Newtonsoft.Json;

Console.WriteLine("Processing users ... \n");
var rawJson = File.ReadAllText("Json\\users.json");

var users = JsonConvert.DeserializeObject<User[]>(rawJson);

var orderedUsers = users.OrderBy(x => x.Name);

foreach (var user in orderedUsers)
{
    Console.WriteLine($"User: {user.Name} - {user.Email}");
}
