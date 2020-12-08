public sealed class Singleton
{
    public static Singleton Instance { get; } = new Singleton();
    public string Message { get; set; }

    private Singleton() => Message = "Hello World!";
}
