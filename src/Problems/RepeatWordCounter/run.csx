var text = "All you need is love, love, Love is all you need";
var word = "love";

var result = GetWordCounter(text, word);
WriteLine($"{word}: {result} times");

public int GetWordCounter(string text, string searchWord)
{
    var result = 0;

    var separators = new char[] { '.', '?', '!', ' ', ';', ':', ',' };
    var words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

    foreach (var word in words)
    {
        if (word.Equals(searchWord))
        {
            result++;
        }
    }

    return result;
}
