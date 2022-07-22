Func<string, string> reverse = (string text) =>
{
    var chars = text.ToCharArray();
    Array.Reverse(chars);

    return new string(chars);
};

Func<string, string> upper = (string text) => text.ToUpper();

string name = "César";
string result = name
    .IfNotNull(reverse)
    .IfNotNull(upper);

WriteLine(result); // RASÉC

public static TOut IfNotNull<TIn, TOut>(this TIn value, Func<TIn, TOut> fnOut)
    where TIn : class
    where TOut : class
{
    if (value == null)
    {
        return null;
    }

    return fnOut(value);
}
