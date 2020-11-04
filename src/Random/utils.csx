public static class RandomUtil
{
    // Generate a random number between two numbers
    public static int GetRandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    // Generate a random string with a given size
    public static string GetRandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();

        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor((26 * random.NextDouble()) + 65)));
            builder.Append(ch);
        }

        if (lowerCase)
            return builder.ToString().ToLower();

        return builder.ToString();
    }

    // Generate a random password
    public static string GetRandomPassword()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(GetRandomString(4, true));
        builder.Append(GetRandomNumber(1000, 9999));
        builder.Append(GetRandomString(2, false));

        return builder.ToString();
    }
}
