// Repeat word counter
// -------------------------------------------
// Get the number of times a word is repeated.
// -------------------------------------------

var text = "All you need is love, love, Love is all you need";
var word = "love";

var result = GetWordCounter(text, word);
WriteLine($"{word}: {result} times");

public static int GetWordCounter(string text, string searchWord)
{
    var result = 0;
    char[] separators = { '.', '?', '!', ' ', ';', ':', ',' };
    var words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

    foreach (var word in words)
    {
        if (word.Equals(searchWord))
            result++;
    }

    return result;
}