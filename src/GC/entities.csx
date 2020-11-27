public class Test
{
    private readonly int _number;

    public Test(int number)
    {
        _number = number;
    }

    public override string ToString() => string.Format("Number format is {0}", _number);

    ~Test()
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine("Here we set free the object");
        Beep(600, 500);
        ResetColor();
    }
}
