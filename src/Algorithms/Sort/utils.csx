// Extensions
// ------------------------------------------------------------

public static void Swap(this int[] array, int i1, int i2)
{
    (array[i2], array[i1]) = (array[i1], array[i2]);
}

public static void CopyTo<T>(this T[] array, T[] target)
{
    Array.Copy(array, target, target.Length);
}
