var text = "Eva, can I see bees in a cave?";

var result = IsPalindrome(text);
WriteLine("Is palindrome: {0}", result ? "Yes" : "No");

public bool IsPalindrome(string text)
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
