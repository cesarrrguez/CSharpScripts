public static class Utils
{
    public static int Days(DateTime from, DateTime to) => (to - from).Days;

    public static string Concat(string text1, string text2) => $"{text1} {text2}";

    public static (Action Increment, Action Substract, Func<int> Get) Counter()
    {
        int i = 0;

        void increment() => i++;
        void substract() => i--;
        int get() => i;

        return ((Action)increment, (Action)substract, (Func<int>)get);
    }

    public static (Action Add, Action Update, Action Delete) OperationsDB()
    {
        return (
                () => WriteLine("Add"),
                () => WriteLine("Update"),
                () => WriteLine("Delete")
        );
    }
}
