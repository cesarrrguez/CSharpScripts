var input = "[()]{}{[()()]()}";
WriteLine($"{input}: {CheckPairedCharacters(input)}");

input = "[(])";
WriteLine($"{input}: {CheckPairedCharacters(input)}");

input = "]";
WriteLine($"{input}: {CheckPairedCharacters(input)}");

public bool CheckPairedCharacters(string text)
{
    var stack = new Stack<char>();
    var map = new Dictionary<char, char>
    {
        { '(', ')' },
        { '{', '}' },
        { '[', ']' }
    };

    foreach (var item in text)
    {
        if (map.ContainsKey(item))
        {
            stack.Push(map[item]);
        }
        else if (stack.Count == 0 || item != stack.Pop())
        {
            return false;
        }
    }

    return stack.Count == 0;
}
