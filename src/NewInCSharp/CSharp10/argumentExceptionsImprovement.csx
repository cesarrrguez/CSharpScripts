#nullable enable

string? info;

//SayHiCSharp9(info);
SayHiCSharp10(info);

public void SayHiCSharp9(string? message) // C# 9
{
    if (message is null)
    {
        throw new ArgumentNullException(nameof(message));
    }

    WriteLine(message);
}

public void SayHiCSharp10(string? message) // C# 10
{
    ArgumentNullException.ThrowIfNull(message);

    WriteLine(message);
}
