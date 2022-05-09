#load "entities.csx"

#r "nuget: ObjectDumper.NET, 3.3.13"

using ObjectDumping;

var users = new List<User>
    {
        new User { Name = "John", Age = 20, },
        new User { Name = "Thomas", Age = 30, },
    };

var usersDump = ObjectDumper.Dump(users);

WriteLine(usersDump);
