var hello = "Hello";
var world = "World";
var obj = new { hello, world };
Console.WriteLine("{0} {1}!", obj.hello, obj.world);

Console.WriteLine();

// Array of anonymous types
var users = new[] {
    new { Name = "James", Age = 47 },
    new { Name = "Olivia", Age = 29 }
};

// Anonymous types loop for
foreach (var user in users)
{
    Console.WriteLine($"Name: {user.Name}, Age: {user.Age}");
}
