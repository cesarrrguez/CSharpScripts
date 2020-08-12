public class Test
{
    private int _number;

    public Test(int number)
    {
        _number = number;
    }

    public override string ToString()
    {
        return string.Format("Number format is {0}", _number);
    }

    ~Test()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Here we set free the object");
        Console.Beep(600, 500);
        Console.ResetColor();
    }
}
