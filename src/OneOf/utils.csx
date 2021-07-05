using System.Text.RegularExpressions;

public static class RegexUtilities
{
    public static bool IsValidEmail(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);

        return match.Success;
    }
}
