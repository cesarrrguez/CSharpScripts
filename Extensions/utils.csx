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
