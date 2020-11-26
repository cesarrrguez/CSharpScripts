var text = "All you need is love, love, Love is all you need";

var result = GetWordsRepetitions(text);
result.ToList().ForEach(x => WriteLine($"{x.Key}: {x.Value}"));

public Dictionary<string, int> GetWordsRepetitions(string text)
{
    var result = new Dictionary<string, int>();

    var separators = new char[] { '.', '?', '!', ' ', ';', ':', ',' };
    var words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

    foreach (var word in words)
    {
        if (result.ContainsKey(word))
        {
            result[word]++;
        }
        else
        {
            result.Add(word, 1);
        }
    }

    return result;
}
