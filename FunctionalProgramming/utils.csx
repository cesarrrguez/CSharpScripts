public static class Utils
{
    public static int Days(DateTime from, DateTime to) => (to - from).Days;

    public static string Concat(string text1, string text2) => $"{text1} {text2}";
}
