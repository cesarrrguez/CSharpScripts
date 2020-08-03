using System.Security.Cryptography;

var text = "qwertyasdf";
var hashedText = GenerateSHA1(text);
Console.WriteLine(hashedText);

private string GenerateSHA1(string text)
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
