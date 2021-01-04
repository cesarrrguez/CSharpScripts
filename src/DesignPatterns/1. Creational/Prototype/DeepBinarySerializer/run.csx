#load "entities.csx"
#load "utils.csx"

#r "nuget: protobuf-net, 3.0.73"

// User
var user = new User("James", 30);
user.Address = new Address("Wall Street", "New York");

// Clone
var userCloned = user.DeepClone();
userCloned.Name = "Olivia";
userCloned.Age = 23;
userCloned.Address.Street = "Oxford Street";
userCloned.Address.City = "London";

// Print
WriteLine(user);
WriteLine(user.Address);
WriteLine();
WriteLine(userCloned);
WriteLine(userCloned.Address);
