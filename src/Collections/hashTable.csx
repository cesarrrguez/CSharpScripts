using System.Collections;

var table = new Hashtable();

table.Add(123, "Hello");
table.Add(234, "World");
table.Add(45, "Everybody");

// Print
Console.WriteLine("Print:");
foreach (DictionaryEntry item in table)
    Console.WriteLine("[{0}] = {1}", item.Key, item.Value);

// Keys
Console.Write("\nKeys: ");
foreach (var key in table.Keys)
    Console.Write("{0} ", key);

// Values
Console.Write("\nValues: ");
foreach (var value in table.Values)
    Console.Write("{0} ", value);

//table.Add(123, "Other"); // Error

// Count
Console.WriteLine();
Console.WriteLine($"Count: {table.Count}");

// Get
Console.WriteLine($"Get 123: {table[123]}");

// Set
table[123] = "Bye";
Console.WriteLine($"Set. Get 123: {table[123]}");

// Add
Console.WriteLine("\nAdd 300:");
table[300] = "Test";
foreach (DictionaryEntry item in table)
    Console.WriteLine("[{0}] = {1}", item.Key, item.Value);

// Contains
Console.WriteLine();
Console.WriteLine($"Contains 300: {table.Contains(300)}");

// Remove
Console.WriteLine("\nRemove 300:");
table.Remove(300);
foreach (DictionaryEntry item in table)
    Console.WriteLine("[{0}] = {1}", item.Key, item.Value);
