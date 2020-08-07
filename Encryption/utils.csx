using System.Security.Cryptography;

public class EncryptionUtil
{
    public static string GetSHA1(string text)
    {
        string result = "";
        SHA1 sha1 = SHA1.Create();

        using (sha1)
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
        string result = "";
        SHA256 sha256 = SHA256Managed.Create();

        using (sha256)
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
