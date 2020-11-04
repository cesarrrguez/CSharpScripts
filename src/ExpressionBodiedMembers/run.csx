// Expression-bodied members
// ----------------------------------------------------------------------------------------
// Expression body definitions let you provide a member's implementation in a very concise, 
// readable form. You can use an expression body definition whenever the logic for any 
// supported member, such as a method or property, consists of a single expression.
// An expression body definition has the following general syntax: member => expression;
// ----------------------------------------------------------------------------------------

#load "entities.csx"

var user1 = new User("George", "Jones");
user1.Age = 21;
user1[0] = "george@gmail.com";
user1[1] = "george.jones@gmail.com";

var user2 = new User(25);
user2.FirstName = "James";
user2.LastName = "Miller";
user2[0] = "james.miller@gmail.com";

Console.WriteLine(user1);
Console.WriteLine(user2);
