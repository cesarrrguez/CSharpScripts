#load "entities.csx"
#load "utils.csx"

var user1 = new User("James");
user1.SetAge(18);
WriteLine(user1);

var user2 = new User("Olivia");
user2.SetAge(15);
WriteLine(user2);

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "users.data");

// Delete file
File.Delete(path);

// Writing
WriteLine("\nWriting ...");
FileUtil.WriteData(user1, path);
FileUtil.WriteData(user2, path);

// Reading
WriteLine("Reading ...\n");
var userData = FileUtil.ReadData(path);
WriteLine(userData);
