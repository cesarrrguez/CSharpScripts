// Operations with two collections
WriteLine("Two collections:");
var list1 = new List<int> { 2, 4, 6, 8, 9 };
var list2 = new List<int> { 2, 5, 6, 7, 9 };

WriteLine($"List 1: {string.Join(", ", list1)}");
WriteLine($"List 2: {string.Join(", ", list2)}");
WriteLine(new string(Enumerable.Repeat('-', 67).ToArray()));

// Except
var except = list1.Except(list2).ToList();
WriteLine($"Except: {String.Join(", ", except)}");

// Intersect
var intersect = list1.Intersect(list2).ToList();
WriteLine($"Intersect: {String.Join(", ", intersect)}");

// Union
var union = list1.Union(list2).ToList();
WriteLine($"Union: {String.Join(", ", union)}");

// Concat
var concat = list1.Concat(list2).ToList();
WriteLine($"Concat: {String.Join(", ", concat)}");

// Distinct
var distinct = concat.Distinct().ToList();
WriteLine($"Distinct: {String.Join(", ", distinct)}");

// Sequence equal
var sequenceEqual = list1.SequenceEqual(list2);
WriteLine($"Sequence equal: {sequenceEqual}");

WriteLine();
