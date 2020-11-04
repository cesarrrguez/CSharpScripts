using System.Collections.Generic;

var dictionary = new Dictionary<int, string>();
dictionary.Add(34, "Hello");

var key = 34;

// ContainsKey option
if (dictionary.ContainsKey(key))
{
    Console.WriteLine($"ContainsKey: {dictionary[key]}");
}

// TryGetValue option
if (dictionary.TryGetValue(key, out var value))
{
    Console.WriteLine($"TryGetValue: {value}");
}
