using System.Runtime.CompilerServices;
using ProtoBuf;

public static class FolderUtil
{
    public static string GetCurrentDirectoryName([CallerFilePath] string fileName = null) => Path.GetDirectoryName(fileName);
}

public static class SerializationUtil
{
    public static void SerializeBinaryData<T>(T obj, string path)
    {
        using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        Serializer.Serialize(stream, obj);
    }

    public static T DeserializeBinaryData<T>(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
        return Serializer.Deserialize<T>(stream);
    }
}
