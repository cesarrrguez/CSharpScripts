#load "entities.csx"
#load "utils.csx"

var user1 = new User("James");
user1.SetAge(18);
Console.WriteLine(user1);

var user2 = new User("Olivia");
user2.SetAge(15);
Console.WriteLine(user2);

var path = "Files/BinaryFiles/users.data";

// Delete file
File.Delete(path);

// Writing
Console.WriteLine("\nWriting ...");
FileUtil.WriteData<User>(user1, path);
FileUtil.WriteData<User>(user2, path);

// Reading
Console.WriteLine("Reading ...\n");
var userData = FileUtil.ReadData<User>(path);
Console.WriteLine(userData);
