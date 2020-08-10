using System.Collections;

var words = new ArrayList();

// Add range
Console.Write("Add range: ");
words.AddRange(new string[] { "Hello", "Word", "everybody" });
for (var i = 0; i < words.Count; i++)
    Console.Write("{0} ", words[i]);

// Add
Console.Write("\nAdd !: ");
words.Add("!");
foreach (var word in words)
    Console.Write("{0} ", word);

// Cast
Console.Write("\nCast: ");
var values = new ArrayList();
values.Add(5);
values.Add(7);
values.Add(4);

for (var i = 0; i < values.Count; i++)
    Console.Write("{0} ", (int)values[i]);

// Contains
Console.Write("\nContains 5: ");
Console.Write(values.Contains(5));

// Insert
Console.Write("\nInsert 55 at 2: ");
values.Insert(2, 55);
for (var i = 0; i < values.Count; i++)
    Console.Write("{0} ", (int)values[i]);

// Remove
Console.Write("\nRemove 55: ");
values.Remove(55);
for (var i = 0; i < values.Count; i++)
    Console.Write("{0} ", (int)values[i]);

// Remove at
Console.Write("\nRemove at 0: ");
values.RemoveAt(0);
for (var i = 0; i < values.Count; i++)
    Console.Write("{0} ", (int)values[i]);
