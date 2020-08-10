using System.Collections.Generic;

var dictionary = new Dictionary<int, string>();
dictionary.Add(34, "Hello");

var key = 34;
string value = null;

// ContainsKey option
if (dictionary.ContainsKey(key))
{
    value = dictionary[key];
}
Console.WriteLine(value);

// TryGetValue option
if (dictionary.TryGetValue(key, out value))
{
    // ...
}
Console.WriteLine(value);
