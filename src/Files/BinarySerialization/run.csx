#load "../../../packages.csx"

#load "entities.csx"
#load "utils.csx"

var user1 = new User("James");
user1.SetAge(18);
WriteLine(user1);

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "users.data");

// Serialization
WriteLine("\nSerializing ...");
SerializationUtil.SerializeBinaryData<User>(user1, path);

// Deserialization
WriteLine("Deserializing ...\n");
var user2 = SerializationUtil.DeserializeBinaryData<User>(path);
WriteLine(user2);
