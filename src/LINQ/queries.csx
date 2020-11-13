// Int array
using System.Diagnostics.CodeAnalysis;

var intArray = new int[] { 1, 2, 10, 3, 2, 55, 666, 18, 2, 100, 2, 41 };
WriteLine($"Int array: {string.Join(", ", intArray)}");
WriteLine(new string(Enumerable.Repeat('-', 67).ToArray()));

// Query syntax
var querySyntax = (from x in intArray where x % 2 == 0 orderby x select x).ToList();
WriteLine($"Query syntax: {string.Join(", ", querySyntax)}");

// Method syntax
var methodSyntax = intArray.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
WriteLine($"Method syntax: {string.Join(", ", methodSyntax)}");

// Filter by index
var indexFilter = intArray.Where((_, i) => i % 2 == 0).ToList();
WriteLine($"Filter by index: {string.Join(", ", indexFilter)}");

// Reverse
var reverse = intArray.Reverse().ToList();
WriteLine($"Reverse: {string.Join(", ", reverse)}");

// Take
var take = intArray.Take(5).ToList();
WriteLine($"Take 5: {string.Join(", ", take)}");

// Take while
var takeWhile = intArray.TakeWhile(x => x < 80).ToList();
WriteLine($"Take while < 80: {string.Join(", ", takeWhile)}");

// Skip
var skip = intArray.Skip(5).ToList();
WriteLine($"Skip 5: {string.Join(", ", skip)}");

// Skip while
var skipWhile = intArray.SkipWhile(x => x < 80).ToList();
WriteLine($"Skip while < 80: {string.Join(", ", skipWhile)}");

// Order by
var orderBy = intArray.OrderBy(x => x).ToList();
WriteLine($"Order by: {string.Join(", ", orderBy)}");

// Order by descending
var orderByDescending = intArray.OrderByDescending(x => x).ToList();
WriteLine($"Order by descending: {string.Join(", ", orderByDescending)}");

// Element at
[SuppressMessage("csharp", "RCS1246", Justification = "ElementAt method use test")]
var elementAt = intArray.ElementAt(3);
WriteLine($"Element at 3: {elementAt}");

// First
[SuppressMessage("csharp", "RCS1246", Justification = "First method use test")]
var first = intArray.First();
WriteLine($"First: {first}");

// First or default
[SuppressMessage("csharp", "RCS1077", Justification = "FirstOrDefault method use test")]
var firstOrDefault = intArray.FirstOrDefault(x => x % 57 == 0);
WriteLine($"First or default: {firstOrDefault}");

// Last
var last = intArray.Last();
WriteLine($"Last: {last}");

// Last or default
var lastOrDefault = intArray.LastOrDefault(x => x % 57 == 0);
WriteLine($"Last or default: {lastOrDefault}");

// Single
try
{
    var single = intArray.Single();
    WriteLine($"Single: {single}");
}
catch (System.Exception)
{
    WriteLine("Single: Exception trowed");
}

// Single or default
var singleOrDefault = intArray.SingleOrDefault(x => x % 57 == 0);
WriteLine($"Single or default: {singleOrDefault}");

// Count
[SuppressMessage("csharp", "RCS1077", Justification = "Count method use test")]
var count = intArray.Count();
WriteLine($"Count: {count}");

// Max
var max = intArray.Max();
WriteLine($"Max: {max}");

// Min
var min = intArray.Min();
WriteLine($"Min: {min}");

// Average
var avg = intArray.Average();
WriteLine($"Average: {avg}");

// Sum
var sum = intArray.Sum();
WriteLine($"Sum: {sum}");

// Aggregation
var aggregation = intArray.Aggregate(0, (i, x) => i + (x * 2));
WriteLine($"Aggregation: {string.Join(", ", aggregation)}");

// Contains
var contains = intArray.Contains(17);
WriteLine($"Contains 17: {contains}");

// Any
[SuppressMessage("csharp", "RCS1080", Justification = "Any method use test")]
var any = intArray.Any();
WriteLine($"Any: {any}");

// All
var all = intArray.All(x => x < 100);
WriteLine($"All: {all}");

// Empty
var empty = Enumerable.Empty<int>().ToList();
WriteLine($"Empty: {string.Join(", ", empty)}");

// Repeat
var repeat = Enumerable.Repeat("Hello", 5).ToList();
WriteLine($"Repeat: {string.Join(", ", repeat)}");

// Range
var range = Enumerable.Range(5, 15).ToList();
WriteLine($"Range: {string.Join(", ", range)}");

WriteLine();
