using System.Threading;

public static class Utils
{
    public static bool IsValid(int num)
    {
        Thread.Sleep(10);

        if (num % 2 != 0) return false;
        if (num % 5 != 0) return false;

        return true;
    }
}
