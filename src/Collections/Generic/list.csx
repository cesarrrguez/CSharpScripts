using System.Collections.Generic;

var values = new List<int>() { 7, 5, 4, 3, 8 };

// Add
values.Add(9);

// Print
WriteLine($"List: {String.Join(", ", values)}");

// Count
WriteLine($"Count: {values.Count}");

// Contains
WriteLine($"Contains 5: {values.Contains(5)}");

// Index of
WriteLine($"Index of 5: {values.IndexOf(5)}");

// Insert
values.Insert(3, 33);
WriteLine($"Insert 33 at 3: {String.Join(", ", values)}");

// Remove at
values.RemoveAt(5);
WriteLine($"Remove at 5: {String.Join(", ", values)}");

// Remove
values.Remove(5);
WriteLine($"Remove 5: {String.Join(", ", values)}");

// Reverse
values.Reverse();
WriteLine($"Reverse: {String.Join(", ", values)}");

// Sort
values.Sort();
WriteLine($"Sort: {String.Join(", ", values)}");

// List - Array - list
var array = values.ToArray();
WriteLine($"To array: {String.Join(", ", array.ToList())}");
