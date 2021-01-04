// Extension GetEnumerator support for foreach loops

public static IEnumerator<T> GetEnumerator<T>(this IEnumerator<T> enumerator) => enumerator;

var enumerator = new List<string> { "César", "James", "Tom" }.GetEnumerator();
foreach (var item in enumerator)
{
    WriteLine($"Welcome {item}!");
}
