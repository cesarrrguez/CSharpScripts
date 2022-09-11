var text1 = "this is my test string";
var text2 = "this is the other test";

var result = GetHammingsDistance(text1, text2);
WriteLine($"Hamming Distance: {result}"); // Hamming Distance: 14

public int GetHammingsDistance(string text1, string text2)
{
    var result = 0;

    if (text1.Length != text2.Length)
    {
        throw new ArgumentException("The two strings must be of the same length");
    }

    for (var i = 0; i < text1.Length; i++)
    {
        if (text1[i] != text2[i])
        {
            result++;
        }
    }

    result += Math.Abs(text1.Length - text2.Length);

    return result;
}
