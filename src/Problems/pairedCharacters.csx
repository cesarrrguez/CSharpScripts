// Paired characters
// --------------------------------------------------------------------------------------
// Given a string formed by (), [] and {}, verify if the corresponding pairs are correct.
// Input: [()]{}{[()()]()} Ok
// Input: [(]) Error
// --------------------------------------------------------------------------------------

var input = "[()]{}{[()()]()}";
WriteLine($"{input}: {CheckPairedCharacters(input)}");

input = "[(])";
WriteLine($"{input}: {CheckPairedCharacters(input)}");

public bool CheckPairedCharacters(string text)
{
    var stack = new Stack<char>();
    var pairs = new Dictionary<char, char>
    {
        { '[', ']' },
        { '(', ')' },
        { '{', '}' }
    };

    foreach (var item in text)
    {
        if (pairs.Keys.Contains(item))
        {
            stack.Push(pairs[item]);
        }
        else
        {
            if (item != stack.Pop()) return false;
        }
    }

    return stack.Count == 0;
}
