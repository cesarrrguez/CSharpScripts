var text = "Hello World";

WriteLine (Reverse(text)); // dlroW olleH
WriteLine (Reverse2(text)); // dlroW olleH

public string Reverse(string text)
{
    var result = "";

    for (var i = text.Length - 1; i >= 0; i--)
    {
        result += text[i];
    }

    return result;
}

public string Reverse2(string text)
{
    var chars = text.ToCharArray();
    Array.Reverse(chars);

    return new string(chars);
}
