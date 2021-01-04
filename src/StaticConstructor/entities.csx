public class Something
{
    //public static int State = 1;

    static Something()
    {
        WriteLine("Type initialization");
    }

    public Something()
    {
        WriteLine("Object initialization");
    }
}
