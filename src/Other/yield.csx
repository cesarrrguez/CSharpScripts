var list = new List<int> { 1, 101, 99, 50, 40, 300 };
var separator = new string(Enumerable.Repeat('-', 69).ToArray());

// Without yield
WriteLine("Without yield:");
WriteLine(separator);
foreach (var item in GetValuesGreaterThan100_1(list))
{
    WriteLine($"Value {item} received");
}

// With yield
WriteLine("\nWith yield:");
WriteLine(separator);
foreach (var item in GetValuesGreaterThan100_2(list))
{
    WriteLine($"Value {item} received");
}

public IEnumerable<int> GetValuesGreaterThan100_1(IEnumerable<int> masterCollection)
{
    var result = new List<int>();

    foreach (var value in masterCollection)
    {
        if (value > 100)
        {
            WriteLine($"Before add value {value}");
            result.Add(value);
            WriteLine($"After add value {value}");
        }
    }

    return result;
}

public IEnumerable<int> GetValuesGreaterThan100_2(List<int> masterCollection)
{
    foreach (var value in masterCollection)
    {
        if (value > 100)
        {
            WriteLine($"Before add value {value}");
            yield return value;
            WriteLine($"After add value {value}");
        }
    }
}
