using System.Runtime.Serialization;
using ProtoBuf;

// Extensions
// ------------------------------------------------------------

public static T DeepClone<T>(this T obj)
{
    if (!typeof(T).IsSerializable) throw new ArgumentException("The class " + typeof(T).ToString() + " is not serializable");

    if (obj == null) return default;

    using var stream = new MemoryStream();
    try
    {
        Serializer.Serialize(stream, obj);
        stream.Seek(0, SeekOrigin.Begin);

        return Serializer.Deserialize<T>(stream);
    }
    catch (SerializationException ex)
    {
        throw new SerializationException(ex.Message, ex);
    }
    catch
    {
        throw;
    }
}
