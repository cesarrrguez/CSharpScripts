// Is palindrome
// ---------------------------------
// Verify if a text is a palindrome.
// ---------------------------------

var text = "Eva, can I see bees in a cave?";

var result = IsPalindrome(text);
WriteLine("Is palindrome: {0}", result ? "Yes" : "No");

public bool IsPalindrome(string text)
{
    char[] separators = { '.', '?', '!', ' ', ';', ':', ',' };
    var lowered = text.ToLower();
    var splitted = lowered.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    var joined = string.Concat(splitted);
    var reversed = new string(joined.Reverse().ToArray());

    return joined.Equals(reversed);
}
