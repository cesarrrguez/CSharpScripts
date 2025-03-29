// Example 1
var names = new[] { "John", "Paul", "George", "Ringo", "Pete", "John" };
IEnumerable<string[]> chunked = names.Chunk(3);

foreach (string[] chunk in chunked)
{
    WriteLine(string.Join(", ", chunk));
}

// John, Paul, George
// Ringo, Pete, John

WriteLine();

// Example 2
IEnumerable<int> values = Enumerable.Range(0, 1000);
int chunkSize = 50;

foreach (int[] chunk in values.Chunk(chunkSize))
{
    Parallel.ForEach(chunk, (item) => WriteLine($"Get id: {item}"));
}

// Get id: 0
// Get id: 12
// Get id: 18
// ...
