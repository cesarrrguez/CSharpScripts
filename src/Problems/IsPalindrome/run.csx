var text = "Eva, can I see bees in a cave?";

var result = IsPalindrome(text);
WriteLine("Is palindrome: {0}", result ? "Yes" : "No"); // Yes

result = IsPalindrome2(text);
WriteLine("Is palindrome: {0}", result ? "Yes" : "No"); // Yes

public bool IsPalindrome(string text)
{
    var separators = new char[] { '.', '?', '!', ' ', ';', ':', ',' };
    var lowered = text.ToLower();
    var splitted = lowered.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    var joined = string.Concat(splitted);
    var reversed = new string(joined.Reverse().ToArray());

    return joined.Equals(reversed);
}

public bool IsPalindrome2(string text)
{
    text = text.ToLower();

    var left = 0;
    var right = text.Length - 1;

    while (left < right)
    {
        if (!char.IsLetterOrDigit(text[left]))
        {
            left++;
            continue;
        }

        if (!char.IsLetterOrDigit(text[right]))
        {
            right--;
            continue;
        }

        if (text[left] != text[right]) return false;

        left++;
        right--;
    }

    return true;
}
