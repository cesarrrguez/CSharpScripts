#load "entities.csx"

var user1 = new User("George", "Jones");
user1.Age = 21;
user1[0] = "george@gmail.com";
user1[1] = "george.jones@gmail.com";

var user2 = new User(25);
user2.FirstName = "James";
user2.LastName = "Miller";
user2[0] = "james.miller@gmail.com";

WriteLine(user1);
WriteLine(user2);
