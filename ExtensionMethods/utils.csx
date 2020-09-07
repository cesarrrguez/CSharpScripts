using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
        array[i] = default(T);
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
    var temp = array[i1];

    array[i1] = array[i2];
    array[i2] = temp;
}

public static List<T> Clone<T>(this List<T> list)
{
    return list.ToList();
}

public static T DeepClone<T>(this T obj)
{
    if (!typeof(T).IsSerializable)
        throw new ArgumentException("The class " + typeof(T).ToString() + " is not serializable");

    if (Object.ReferenceEquals(obj, null))
        return default(T);

    using var stream = new MemoryStream();
    try
    {
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, obj);
        stream.Seek(0, SeekOrigin.Begin);

        return (T)formatter.Deserialize(stream);
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

public static string PropertyList(this object obj)
{
    var properties = obj.GetType().GetProperties();
    var sb = new StringBuilder();

    foreach (var property in properties)
    {
        sb.AppendLine(property.Name + ": " + property.GetValue(obj, null));
    }

    return sb.ToString();
}

public static string ToYesNoString(this bool value)
{
    return value ? "Yes" : "No";
}
