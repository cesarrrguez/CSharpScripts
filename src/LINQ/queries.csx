// Int array
using System.Diagnostics.CodeAnalysis;

var intArray = new int[] { 1, 2, 10, 3, 2, 55, 666, 18, 2, 100, 2, 41 };
Console.WriteLine($"Int array: {string.Join(", ", intArray)}");
Console.WriteLine(new string(Enumerable.Repeat('-', 67).ToArray()));

// Query syntax
var querySyntax = (from x in intArray where x % 2 == 0 orderby x select x).ToList();
Console.WriteLine($"Query syntax: {string.Join(", ", querySyntax)}");

// Method syntax
var methodSyntax = intArray.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
Console.WriteLine($"Method syntax: {string.Join(", ", methodSyntax)}");

// Filter by index
var indexFilter = intArray.Where((_, i) => i % 2 == 0).ToList();
Console.WriteLine($"Filter by index: {string.Join(", ", indexFilter)}");

// Reverse
var reverse = intArray.Reverse().ToList();
Console.WriteLine($"Reverse: {string.Join(", ", reverse)}");

// Take
var take = intArray.Take(5).ToList();
Console.WriteLine($"Take 5: {string.Join(", ", take)}");

// Take while
var takeWhile = intArray.TakeWhile(x => x < 80).ToList();
Console.WriteLine($"Take while < 80: {string.Join(", ", takeWhile)}");

// Skip
var skip = intArray.Skip(5).ToList();
Console.WriteLine($"Skip 5: {string.Join(", ", skip)}");

// Skip while
var skipWhile = intArray.SkipWhile(x => x < 80).ToList();
Console.WriteLine($"Skip while < 80: {string.Join(", ", skipWhile)}");

// Order by
var orderBy = intArray.OrderBy(x => x).ToList();
Console.WriteLine($"Order by: {string.Join(", ", orderBy)}");

// Order by descending
var orderByDescending = intArray.OrderByDescending(x => x).ToList();
Console.WriteLine($"Order by descending: {string.Join(", ", orderByDescending)}");

// Element at
[SuppressMessage("csharp", "RCS1246", Justification = "ElementAt method use test")]
var elementAt = intArray.ElementAt(3);
Console.WriteLine($"Element at 3: {elementAt}");

// First
[SuppressMessage("csharp", "RCS1246", Justification = "First method use test")]
var first = intArray.First();
Console.WriteLine($"First: {first}");

// First or default
[SuppressMessage("csharp", "RCS1077", Justification = "FirstOrDefault method use test")]
var firstOrDefault = intArray.FirstOrDefault(x => x % 57 == 0);
Console.WriteLine($"First or default: {firstOrDefault}");

// Last
var last = intArray.Last();
Console.WriteLine($"Last: {last}");

// Last or default
var lastOrDefault = intArray.LastOrDefault(x => x % 57 == 0);
Console.WriteLine($"Last or default: {lastOrDefault}");

// Single
try
{
    var single = intArray.Single();
    Console.WriteLine($"Single: {single}");
}
catch (System.Exception)
{
    Console.WriteLine("Single: Exception trowed");
}

// Single or default
var singleOrDefault = intArray.SingleOrDefault(x => x % 57 == 0);
Console.WriteLine($"Single or default: {singleOrDefault}");

// Count
[SuppressMessage("csharp", "RCS1077", Justification = "Count method use test")]
var count = intArray.Count();
Console.WriteLine($"Count: {count}");

// Max
var max = intArray.Max();
Console.WriteLine($"Max: {max}");

// Min
var min = intArray.Min();
Console.WriteLine($"Min: {min}");

// Average
var avg = intArray.Average();
Console.WriteLine($"Average: {avg}");

// Sum
var sum = intArray.Sum();
Console.WriteLine($"Sum: {sum}");

// Aggregation
var aggregation = intArray.Aggregate(0, (i, x) => i + (x * 2));
Console.WriteLine($"Aggregation: {string.Join(", ", aggregation)}");

// Contains
var contains = intArray.Contains(17);
Console.WriteLine($"Contains 17: {contains}");

// Any
[SuppressMessage("csharp", "RCS1080", Justification = "Any method use test")]
var any = intArray.Any();
Console.WriteLine($"Any: {any}");

// All
var all = intArray.All(x => x < 100);
Console.WriteLine($"All: {all}");

// Empty
var empty = Enumerable.Empty<int>().ToList();
Console.WriteLine($"Empty: {string.Join(", ", empty)}");

// Repeat
var repeat = Enumerable.Repeat("Hello", 5).ToList();
Console.WriteLine($"Repeat: {string.Join(", ", repeat)}");

// Range
var range = Enumerable.Range(5, 15).ToList();
Console.WriteLine($"Range: {string.Join(", ", range)}");

Console.WriteLine();
