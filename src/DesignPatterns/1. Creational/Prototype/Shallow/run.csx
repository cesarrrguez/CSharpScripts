#load "entities.csx"

// User
var user = new User("James", 30);

// Clone
var userCloned = user.Clone() as User;
userCloned.Name = "Olivia";
userCloned.Age = 23;

// Print
WriteLine(user);
WriteLine(userCloned);
