
using System.Runtime.Serialization.Formatters.Binary;

public static class SerializationUtil
{
    public static void SerializeBinaryData<T>(T obj, string path)
    {
        var formater = new BinaryFormatter();

        using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        formater.Serialize(stream, obj);
    }

    public static T DeserializeBinaryData<T>(string path)
    {
        var formater = new BinaryFormatter();

        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
        var result = formater.Deserialize(stream);

        return (T)result;
    }
}
