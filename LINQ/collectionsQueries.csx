// Operations with two collections
Console.WriteLine("Two collections:");
var list1 = new List<int> { 2, 4, 6, 8, 9 };
var list2 = new List<int> { 2, 5, 6, 7, 9 };

Console.WriteLine($"List 1: {string.Join(", ", list1)}");
Console.WriteLine($"List 2: {string.Join(", ", list2)}");
Console.WriteLine(new string(Enumerable.Repeat('-', 67).ToArray()));

// Except
var except = list1.Except(list2).ToList();
Console.WriteLine($"Except: {String.Join(", ", except)}");

// Intersect
var intersect = list1.Intersect(list2).ToList();
Console.WriteLine($"Intersect: {String.Join(", ", intersect)}");

// Union
var union = list1.Union(list2).ToList();
Console.WriteLine($"Union: {String.Join(", ", union)}");

// Concat
var concat = list1.Concat(list2).ToList();
Console.WriteLine($"Concat: {String.Join(", ", concat)}");

// Distinct
var distinct = concat.Distinct().ToList();
Console.WriteLine($"Distinct: {String.Join(", ", distinct)}");

// Sequence equal
var sequenceEqual = list1.SequenceEqual(list2);
Console.WriteLine($"Sequence equal: {sequenceEqual}");

Console.WriteLine();
