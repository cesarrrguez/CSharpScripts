#load "entities.csx"
#load "utils.csx"

var user1 = new User("James");
user1.SetAge(18);
Console.WriteLine(user1);

var path = "Files/BinarySerialization/users.data";

// Serialization
Console.WriteLine("\nSerializing ...");
SerializationUtil.SerializeBinaryData<User>(user1, path);

// Deserialization
Console.WriteLine("Deserializing ...\n");
var user2 = SerializationUtil.DeserializeBinaryData<User>(path);
Console.WriteLine(user2);
