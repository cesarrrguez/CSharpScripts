using System.Collections;

var list = new SortedList();

list.Add(123, "Hello");
list.Add(234, "World");
list.Add(45, "Everybody");

// Print
Console.WriteLine("Print:");
foreach (DictionaryEntry item in list)
    Console.WriteLine("[{0}] = {1}", item.Key, item.Value);

// Count
Console.WriteLine($"\nCount: {list.Count}");

// Contains
Console.WriteLine($"Contains 300: {list.Contains(300)}");

// Contains key
Console.WriteLine($"Contains key 45: {list.ContainsKey(45)}");

// Contains value
Console.WriteLine($"Contains value 'Hello': {list.ContainsValue("Hello")}");

// Get key
Console.WriteLine($"Get key 2: {list.GetKey(2)}");

// Get by index
Console.WriteLine($"Get by index 2: {list.GetByIndex(2)}");
