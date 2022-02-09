var hello = "Hello";
var world = "World";
var obj = new { hello, world };
WriteLine("{0} {1}!", obj.hello, obj.world);

WriteLine();

// Array
var users = new[] {
    new { Name = "James", Age = 47 },
    new { Name = "Olivia", Age = 29 }
};

foreach (var user in users)
{
    //user.Name = ""; // Error -> read only
    WriteLine($"Name: {user.Name}, Age: {user.Age}");
}
