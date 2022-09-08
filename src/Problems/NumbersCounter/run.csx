using System.Text.RegularExpressions;

var text = "All 1 you 2 need 345 is love, 778love, 985Love is3 all you4 4need";

var result = GetNumbersCounter(text);
WriteLine($"{result} numbers"); // 14 numbers

public int GetNumbersCounter(string text)
{
    const string pattern = "[0-9]";

    var regex = new Regex(pattern);

    return regex.Matches(text).Count;
}
