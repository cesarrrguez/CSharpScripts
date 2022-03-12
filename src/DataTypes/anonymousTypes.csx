// Basic
using System.Collections.Generic;

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

WriteLine();

// Query
public class Beer
{
    public string Name { get; set; }
    public string Style { get; set; }
}

List<Beer> beers = new List<Beer>() {
    new Beer() { Name = "Mahou", Style = "Classic" },
    new Beer() { Name = "Amstell", Style="Popular" }
};

var namesOfBeers = from x in beers
                   select new { Name123 = x.Name };

namesOfBeers.ToList().ForEach(x => WriteLine(x.Name123));

WriteLine();

// Methods
Action<int> FunctionInt = (num) => WriteLine(num);

var some = new
{
    Name = "Something",
    Age = 77,
    Function = FunctionInt
};
some.Function(7);

WriteLine();

// Reflection
foreach (var item in some.GetType().GetProperties())
{
    WriteLine($"{item.Name} {item.GetValue(some)} {some.GetType().GetProperty(item.Name)}");
}
