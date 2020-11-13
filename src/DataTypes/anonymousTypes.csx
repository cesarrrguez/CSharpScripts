var hello = "Hello";
var world = "World";
var obj = new { hello, world };
WriteLine("{0} {1}!", obj.hello, obj.world);

WriteLine();

// Array of anonymous types
var users = new[] {
    new { Name = "James", Age = 47 },
    new { Name = "Olivia", Age = 29 }
};

// Anonymous types loop for
foreach (var user in users)
{
    WriteLine($"Name: {user.Name}, Age: {user.Age}");
}
