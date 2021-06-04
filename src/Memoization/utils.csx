// Extensions
// ------------------------------------------------------------

using System.Collections.Concurrent;

public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> func)
{
    var cache = new ConcurrentDictionary<T, TResult>();
    return (a) => cache.GetOrAdd(a, func);
}
