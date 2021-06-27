using System.Collections;

var table = new Hashtable();

table.Add(123, "Hello");
table.Add(234, "World");
table.Add(45, "Everybody");

// Print
WriteLine("Print:");

foreach (DictionaryEntry item in table)
{
    WriteLine("[{0}] = {1}", item.Key, item.Value);
}

// Keys
Write("\nKeys: ");

foreach (var key in table.Keys)
{
    Write("{0} ", key);
}

// Values
Write("\nValues: ");

foreach (var value in table.Values)
{
    Write("{0} ", value);
}

//table.Add(123, "Other"); // Error

// Count
WriteLine();
WriteLine($"Count: {table.Count}");

// Get
WriteLine($"Get 123: {table[123]}");

// Set
table[123] = "Bye";
WriteLine($"Set. Get 123: {table[123]}");

// Add
WriteLine("\nAdd 300:");
table[300] = "Test";

foreach (DictionaryEntry item in table)
{
    WriteLine("[{0}] = {1}", item.Key, item.Value);
}

// Contains
WriteLine();
WriteLine($"Contains 300: {table.Contains(300)}");

// Remove
WriteLine("\nRemove 300:");
table.Remove(300);

foreach (DictionaryEntry item in table)
{
    WriteLine("[{0}] = {1}", item.Key, item.Value);
}
