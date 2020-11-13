#load "entities.csx"

var table = new HashTable<int, string>();

// Add
table.Add(123, "Hello");
table.Add(234, "World");
table.Add(45, "Everybody");

// Print
WriteLine($"Print: {string.Join(" - ", table.ToList())}");

// Contains key
WriteLine($"Contains key 234: {table.ContainsKey(234)}");

// Contains value
WriteLine($"Contains value Hello: {table.ContainsValue("Hello")}");

// Find by key
var node = table.FindByKey(45);
WriteLine($"Find by key 45: {node}");

// Find by value
node = table.FindByValue("World");
WriteLine($"Find by value World: {node}");

// Remove
table.Remove(45);
WriteLine($"Remove 45: {string.Join(" - ", table.ToList())}");

// Get value by index
var value = table[123];
WriteLine($"Get [123]: {value}");

// Set value by index
table[123] = "Bye";
WriteLine($"Set [123] to Bye: {string.Join(" - ", table.ToList())}");

// Count
WriteLine($"Count: {table.Count()}");

// Clear
table.Clear();
WriteLine($"Clear: {string.Join(" - ", table.ToList())}");
