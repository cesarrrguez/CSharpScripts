var text = "All you need is love, love, Love is all you need";
var character = 'o';

var result = GetCharactersCounter(text, character);
WriteLine($"{character}: {result} times"); // o: 5 times

result = GetCharactersCounter2(text, character);
WriteLine($"{character}: {result} times"); // o: 5 times

public int GetCharactersCounter(string text, char searchCharacter)
{
    var result = 0;

    foreach (var character in text)
    {
        if (character.Equals(searchCharacter))
        {
            result++;
        }
    }

    return result;
}

public int GetCharactersCounter2(string text, char searchCharacter)
{
    return text.Count(c => c == searchCharacter);
}
