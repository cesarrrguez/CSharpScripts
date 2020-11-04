#load "entities.csx"

var table = new HashTable<int, string>();

// Add
table.Add(123, "Hello");
table.Add(234, "World");
table.Add(45, "Everybody");

// Print
Console.WriteLine($"Print: {string.Join(" - ", table.ToList())}");

// Contains key
Console.WriteLine($"Contains key 234: {table.ContainsKey(234)}");

// Contains value
Console.WriteLine($"Contains value Hello: {table.ContainsValue("Hello")}");

// Find by key
var node = table.FindByKey(45);
Console.WriteLine($"Find by key 45: {node}");

// Find by value
node = table.FindByValue("World");
Console.WriteLine($"Find by value World: {node}");

// Remove
table.Remove(45);
Console.WriteLine($"Remove 45: {string.Join(" - ", table.ToList())}");

// Get value by index
var value = table[123];
Console.WriteLine($"Get [123]: {value}");

// Set value by index
table[123] = "Bye";
Console.WriteLine($"Set [123] to Bye: {string.Join(" - ", table.ToList())}");

// Count
Console.WriteLine($"Count: {table.Count()}");

// Clear
table.Clear();
Console.WriteLine($"Clear: {string.Join(" - ", table.ToList())}");
