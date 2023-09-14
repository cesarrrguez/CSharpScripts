#load "../../../packages.csx"

#load "entities.csx"

using ObjectDumping;

var users = new List<User>
    {
        new User { Name = "John", Age = 20, },
        new User { Name = "Thomas", Age = 30, },
    };

var usersDump = ObjectDumper.Dump(users);

WriteLine(usersDump);
