public record Data(int Age);
public record User(string Name, Data Data);

User user = new User("César", new(21));
string result = ExpressionCSharp10(user);

#pragma warning disable IDE0170
private static string ExpressionCSharp9(User user) => // C# 9
    user switch
    {

        { Data: { Age: >= 18 } } => "Adult",
        { Data: { Age: < 18 } } => "Child",
        _ => throw new NotSupportedException()
    };
#pragma warning restore IDE0170

private static string ExpressionCSharp10(User user) => // C# 10
    user switch
    {

        { Data.Age: >= 18 } => "Adult",
        { Data.Age: < 18 } => "Child",
        _ => throw new NotSupportedException()
    };
