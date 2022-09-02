var text = "All you need is love, love, Love is all you need";

var result = GetWordsCounter(text);
WriteLine($"{result} words"); // 11 words

public int GetWordsCounter(string text)
{
    var separators = new char[] { '.', '?', '!', ' ', ';', ':', ',' };
    var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

    return words.Length;
}
