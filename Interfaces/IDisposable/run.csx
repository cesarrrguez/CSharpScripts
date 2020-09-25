#load "entities.csx"

var obj = new DerivedClass(5);
Console.WriteLine(obj);
obj.Dispose();

Console.WriteLine();

// Best use of dispose
if (obj is IDisposable)
    obj.Dispose();

// A way to guarantee that dispose is invoked
try
{
    Console.WriteLine(obj);
}
finally
{
    Console.WriteLine();
    obj.Dispose();
}

// Automatic dispose invoked
using var obj2 = new DerivedClass(7);
Console.WriteLine(obj2);
