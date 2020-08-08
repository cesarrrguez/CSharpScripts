using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static void Populate<T>(this T[] source, T value)
{
    for (var i = 0; i < source.Length; i++)
    {
        source[i] = value;
    }
}

public static void CopyTo<T>(this T[] source, T[] target)
{
    Array.Copy(source, target, target.Length);
}

public static void Clear<T>(this T[] target)
{
    if (target == null) return;

    for (var i = 0; i < target.Length; i++)
    {
        target[i] = default(T);
    }
}

public static bool Contains<T>(this T[] source, T value)
{
    return Array.IndexOf(source, value) != -1;
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

public static T[] Slice<T>(this T[] source, int start, int end)
{
    if (end < 0)
    {
        end = source.Length + end;
    }

    var result = new T[end - start];

    for (var i = 0; i < result.Length; i++)
    {
        result[i] = source[i + start];
    }

    return result;
}

public static List<T> Clone<T>(this List<T> list)
{
    return list.ToList();
}

public static T DeepClone<T>(this T source)
{
    if (!typeof(T).IsSerializable)
        throw new ArgumentException("The class " + typeof(T).ToString() + " is not serializable");

    if (Object.ReferenceEquals(source, null))
        return default(T);

    using (var stream = new MemoryStream())
    {
        try
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);

            return (T)formatter.Deserialize(stream);
        }
        catch (SerializationException ex)
        {
            throw new ArgumentException(ex.Message, ex);
        }
        catch
        {
            throw;
        }
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
