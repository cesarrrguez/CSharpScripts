using System.Collections;

var list = new SortedList();

list.Add(123, "Hello");
list.Add(234, "World");
list.Add(45, "Everybody");

// Print
WriteLine("Print:");
foreach (DictionaryEntry item in list)
    WriteLine("[{0}] = {1}", item.Key, item.Value);

// Count
WriteLine($"\nCount: {list.Count}");

// Contains
WriteLine($"Contains 300: {list.Contains(300)}");

// Contains key
WriteLine($"Contains key 45: {list.ContainsKey(45)}");

// Contains value
WriteLine($"Contains value 'Hello': {list.ContainsValue("Hello")}");

// Get key
WriteLine($"Get key 2: {list.GetKey(2)}");

// Get by index
WriteLine($"Get by index 2: {list.GetByIndex(2)}");
