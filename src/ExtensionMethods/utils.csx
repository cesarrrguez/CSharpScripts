using System.Reflection;
using System.Runtime.Serialization;
using ProtoBuf;

// Extensions
// ------------------------------------------------------------

public static void Populate<T>(this T[] array, T value)
{
    for (var i = 0; i < array.Length; i++)
    {
        array[i] = value;
    }
}

public static void CopyTo<T>(this T[] array, T[] target)
{
    Array.Copy(array, target, target.Length);
}

public static void Clear<T>(this T[] array)
{
    if (array == null) return;

    for (var i = 0; i < array.Length; i++)
    {
        array[i] = default;
    }
}

public static bool Contains<T>(this T[] array, T value)
{
    return Array.IndexOf(array, value) != -1;
}

public static double? SumSlow(this double[] array)
{
    var total = 0d;

    for (var i = 0; i < array.Length; i++)
    {
        total += array[i];
    }

    return total;
}

public static T[] Slice<T>(this T[] array, int start, int end)
{
    if (end < 0)
    {
        end = array.Length + end;
    }

    var result = new T[end - start];

    for (var i = 0; i < result.Length; i++)
    {
        result[i] = array[i + start];
    }

    return result;
}

public static void Swap<T>(this T[] array, int i1, int i2)
{
    (array[i2], array[i1]) = (array[i1], array[i2]);
}

public static List<T> Clone<T>(this List<T> list)
{
    return list.ToList();
}

public static List<T> CloneList<T>(this List<T> list) where T : ICloneable
{
    return list.ConvertAll(item => (T)item.Clone());
}

public static T DeepClone<T>(this T obj)
{
    if (typeof(T).GetCustomAttribute<SerializableAttribute>() == null)
    {
        throw new ArgumentException($"The class {typeof(T)} is not serializable");
    }

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
}

public static string PropertyList(this object obj)
{
    var properties = obj.GetType().GetProperties();
    var sb = new StringBuilder();

    foreach (var property in properties)
    {
        sb.Append(property.Name).Append(": ").Append(property.GetValue(obj, null)).AppendLine();
    }

    return sb.ToString();
}

public static string ToYesNoString(this bool value) => value ? "Yes" : "No";
