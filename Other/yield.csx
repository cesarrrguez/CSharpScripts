var list = new List<int> { 1, 101, 99, 50, 40, 300 };

// Without yield
var list_1 = GetValuesGreaterThan100_1(list);
Console.WriteLine(String.Join(", ", list_1));

// With yield
var list_2 = GetValuesGreaterThan100_2(list);
Console.WriteLine(String.Join(", ", list_2));

public List<int> GetValuesGreaterThan100_1(List<int> masterCollection)
{
    var result = new List<int>();

    foreach (var value in masterCollection)
        if (value > 100)
            result.Add(value);

    return result;
}

public IEnumerable<int> GetValuesGreaterThan100_2(List<int> masterCollection)
{
    foreach (var value in masterCollection)
        if (value > 100)
            yield return value;
}
