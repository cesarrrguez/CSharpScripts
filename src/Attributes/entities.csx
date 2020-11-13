//[Obsolete]
[Obsolete("Use Test2")]
public class Test
{
    public Test()
    {
        WriteLine("Version 1");
    }
}

[Data("Implemented by César")]
public class Test2
{
    public Test2()
    {
        WriteLine("Version 2");
    }
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public sealed class DataAttribute : System.Attribute
{
    public string Data { get; }

    public DataAttribute() { }

    public DataAttribute(string data)
    {
        Data = data;
    }
}
