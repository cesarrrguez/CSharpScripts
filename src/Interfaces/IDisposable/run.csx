// IDisposable
// -------------------------------------------------------
// Provides a mechanism for releasing unmanaged resources.
// -------------------------------------------------------

#load "entities.csx"

var obj = new DerivedClass(5);
WriteLine(obj);
obj.Dispose();

WriteLine();

// Best use of dispose
if (obj is IDisposable)
    obj.Dispose();

// A way to guarantee that dispose is invoked
try
{
    WriteLine(obj);
}
finally
{
    WriteLine();
    obj.Dispose();
}

// Automatic dispose invoked
using (var obj2 = new DerivedClass(7))
{
    WriteLine(obj2);
}
