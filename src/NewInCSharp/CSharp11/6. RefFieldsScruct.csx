public ref struct MyStruct
{
    public ref int value;

    public int GetValue()
    {
        if (System.Runtime.CompilerServices.Unsafe.IsNullRef(ref value))
        {
            throw new InvalidOperationException("The value is not initialized");
        }

        return value;
    }
}
