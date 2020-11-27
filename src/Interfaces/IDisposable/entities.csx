public class BaseClass : IDisposable
{
    // To detect redundant calls
    private bool _disposed = false;

    ~BaseClass() => Dispose(false);

    // Public implementation of Dispose pattern
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            WriteLine("Disposing {0} ...", nameof(BaseClass));

            // Dispose managed state (managed objects)
            // ...
        }

        // Free unmanaged resources (unmanaged objects)
        // ...

        // Set large fields to null
        // ...

        _disposed = true;
    }
}

public class DerivedClass : BaseClass
{
    private readonly int _number;

    // To detect redundant calls
    private bool _disposed;

    ~DerivedClass() => Dispose(false);

    public DerivedClass(int number)
    {
        _number = number;
    }

    public override string ToString() => string.Format("Number format is {0}", _number);

    // Protected implementation of Dispose pattern
    protected override void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            WriteLine("Disposing {0} ...", nameof(DerivedClass));

            // Dispose managed state (managed objects)
            // ...
        }

        // Free unmanaged resources (unmanaged objects)
        // ...

        // Set large fields to null
        // ...

        _disposed = true;

        // Call base class implementation
        base.Dispose(disposing);
    }
}
