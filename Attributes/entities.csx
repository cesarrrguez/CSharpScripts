//[Obsolete]
[Obsolete("Use Test2")]
public class Test
{
    public Test()
    {
        Console.WriteLine("Version 1");
    }
}

[Data("Implemented by César")]
public class Test2
{
    public Test2()
    {
        Console.WriteLine("Version 2");
    }
}

public sealed class DataAttribute : System.Attribute
{
    public string Data { get; private set; }

    public DataAttribute() { }

    public DataAttribute(string data)
    {
        Data = data;
    }
}
