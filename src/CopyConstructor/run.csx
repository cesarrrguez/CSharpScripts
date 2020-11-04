#load "entities.csx"

// Create a User object by using the instance constructor
var user1 = new User("George", 40);

// Create another User object, copying user1
var user2 = new User(user1);

// Change each user age
user1.Age = 39;
user2.Age = 41;

// Change user2 name
user2.Name = "Charles";

// Print users
Console.WriteLine(user1);
Console.WriteLine(user2);
