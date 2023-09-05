WriteLine("Print from 0 to 10");
foreach (var i in 0..10)
{
    WriteLine(i);
}


public class CustomIntEnumerator
{
    private int _current;
    private readonly int _end;

    public CustomIntEnumerator(Range range)
    {
        if (range.End.IsFromEnd)
        {
            throw new NotSupportedException();
        }

        _current = range.Start.Value - 1;
        _end = range.End.Value;
    }

    public int Current => _current;

    public bool MoveNext()
    {
        _current++;
        return _current <= _end;
    }
}

// Extensions
// ------------------------------------------------------------
public static CustomIntEnumerator GetEnumerator(this Range range)
{
    return new CustomIntEnumerator(range);
}
