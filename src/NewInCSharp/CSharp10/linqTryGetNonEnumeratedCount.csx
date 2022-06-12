var firstSet = new[] { "James Bond" };
var secondSet = new[] { "John Doe" };
var thirdSet = new[] { "Marie Curie" };

IEnumerable<string> names = firstSet.Concat(secondSet).Concat(thirdSet);

//var count = names.Count();  // Multiple enumeration

// Attempts to determine the number of elements in a sequence without forcing an enumeration
if (names.TryGetNonEnumeratedCount(out var count))
{
    WriteLine(count);  // 3
}

IOrderedEnumerable<string> orderedNames = names.OrderBy(x => x);
