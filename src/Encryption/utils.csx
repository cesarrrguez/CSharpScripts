using System.Security.Cryptography;

public static class EncryptionUtil
{
    public static string GetSHA1(string text)
    {
        using var sha1 = SHA1.Create();
        var sb = new StringBuilder();

        var data = Encoding.UTF8.GetBytes(text);
        var hash = sha1.ComputeHash(data);

        foreach (byte b in hash)
            sb.Append(b.ToString("x2").ToLower());

        return sb.ToString();
    }

    public static string GetSHA256(string text)
    {
        using var sha256 = SHA256.Create();
        var sb = new StringBuilder();

        var data = Encoding.UTF8.GetBytes(text);
        var hash = sha256.ComputeHash(data);

        foreach (byte b in hash)
            sb.Append(b.ToString("x2").ToLower());

        return sb.ToString();
    }
}
