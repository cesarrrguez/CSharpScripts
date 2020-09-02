using System.Security.Cryptography;

public class EncryptionUtil
{
    public static string GetSHA1(string text)
    {
        var result = "";

        using (var sha1 = SHA1.Create())
        {
            StringBuilder sb = new StringBuilder();

            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] hash = sha1.ComputeHash(data);

            foreach (byte b in hash)
                sb.Append(b.ToString("x2").ToLower());

            result = sb.ToString();
        }

        return result;
    }

    public static string GetSHA256(string text)
    {
        var result = "";

        using (var sha256 = SHA256Managed.Create())
        {
            StringBuilder sb = new StringBuilder();

            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] hash = sha256.ComputeHash(data);

            foreach (byte b in hash)
                sb.Append(b.ToString("x2").ToLower());

            result = sb.ToString();
        }

        return result;
    }
}
