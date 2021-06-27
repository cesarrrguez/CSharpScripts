using System.Collections;

var words = new ArrayList();

// Add range
Write("Add range: ");
words.AddRange(new string[] { "Hello", "Word", "everybody" });

for (var i = 0; i < words.Count; i++)
{
    Write("{0} ", words[i]);
}

// Add
Write("\nAdd !: ");
words.Add("!");

foreach (var word in words)
{
    Write("{0} ", word);
}

// Cast
Write("\nCast: ");
var values = new ArrayList();
values.Add(5);
values.Add(7);
values.Add(4);

for (var i = 0; i < values.Count; i++)
{
    Write("{0} ", (int)values[i]);
}

// Contains
Write("\nContains 5: ");
Write(values.Contains(5));

// Insert
Write("\nInsert 55 at 2: ");
values.Insert(2, 55);

for (var i = 0; i < values.Count; i++)
{
    Write("{0} ", (int)values[i]);
}

// Remove
Write("\nRemove 55: ");
values.Remove(55);

for (var i = 0; i < values.Count; i++)
{
    Write("{0} ", (int)values[i]);
}

// Remove at
Write("\nRemove at 0: ");
values.RemoveAt(0);

for (var i = 0; i < values.Count; i++)
{
    Write("{0} ", (int)values[i]);
}
