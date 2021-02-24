// Operations with two collections
WriteLine("Two collections:");
var list1 = new List<int> { 2, 4, 6, 8, 9 };
var list2 = new List<int> { 2, 5, 6, 7, 9 };

WriteLine($"List 1: {string.Join(", ", list1)}");
WriteLine($"List 2: {string.Join(", ", list2)}");
WriteLine(new string(Enumerable.Repeat('-', 67).ToArray()));

// Except
var except = list1.Except(list2).ToList();
WriteLine($"Except: {string.Join(", ", except)}");

// Intersect
var intersect = list1.Intersect(list2).ToList();
WriteLine($"Intersect: {string.Join(", ", intersect)}");

// Union
var union = list1.Union(list2).ToList();
WriteLine($"Union: {string.Join(", ", union)}");

// Concat
var concat = list1.Concat(list2).ToList();
WriteLine($"Concat: {string.Join(", ", concat)}");

// Distinct
var distinct = concat.Distinct().ToList();
WriteLine($"Distinct: {string.Join(", ", distinct)}");

// Sequence equal
var sequenceEqual = list1.SequenceEqual(list2);
WriteLine($"Sequence equal: {sequenceEqual}");
