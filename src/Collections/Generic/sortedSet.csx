using System.Collections.Generic;

var set = new SortedSet<int>();

// Add
set.Add(7);
set.Add(5);
set.Add(4);
set.Add(3);
set.Add(8);
set.Add(9);

// Print
WriteLine($"Set: {string.Join(", ", set)}");
