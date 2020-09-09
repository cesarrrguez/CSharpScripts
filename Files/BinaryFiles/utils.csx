using System.IO;

public static class FileUtil
{
    public static void WriteData<T>(T obj, string path)
    {
        using var stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
        var writter = new BinaryWriter(stream);

        writter.Write(obj.ToString());
    }

    public static string ReadData(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
        var reader = new BinaryReader(stream);
        var stringBuilder = new StringBuilder();

        while (reader.PeekChar() >= 0)
        {
            stringBuilder.Append(reader.ReadString()).Append('\n');
        }

        return stringBuilder.ToString();
    }
}
