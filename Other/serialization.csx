using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

public class SerializeData
{
    public static void Serialize(object objectData, string path)
    {
        var serializer = JSONSettingsSerialization.GetSerializer(objectData.GetType());

        using (var sw = new StreamWriter(path))
        using (var jtw = new JsonTextWriter(sw))
        {
            serializer.Serialize(jtw, objectData);
        }
    }

    public static void SerializeBinaryData<T>(T obj, string path)
    {
        var bf = new BinaryFormatter();
        var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

        bf.Serialize(fs, obj);
    }
}

public class DesSerializeData
{
    public static T DesSerialize<T>(string path)
    {
        var serializer = JSONSettingsSerialization.GetSerializer(typeof(T));

        using (var sw = new JsonTextReader(new StreamReader(path)))
        {
            return serializer.Deserialize<T>(sw);
        }
    }

    public static T DeserializeBinaryData<T>(string path)
    {
        var bf = new BinaryFormatter();
        var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        var result = bf.Deserialize(fs);

        return (T)result;
    }
}

public class JSONSettingsSerialization
{
    public static JsonSerializerSettings GetSettings(Type typeData)
    {
        var settingsJson = new JsonSerializerSettings();
        settingsJson.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        settingsJson.Converters = GetConverters(typeData);

        return settingsJson;
    }

    private static List<JsonConverter> GetConverters(Type typeData)
    {
        return new List<JsonConverter>();
    }

    public static JsonSerializer GetSerializer(Type typeData)
    {
        var serializer = new JsonSerializer();
        serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        var converters = GetConverters(typeData);

        foreach (var converter in converters)
            serializer.Converters.Add(converter);

        return serializer;
    }
}
