// Checked
// ----------------------------------------------------------------
// Block keyword that enables arithmetic overflow checking. 
// Normally, if an integer operation exceeds the maximum or minimum 
// value that the type can handle, the operation proceeds anyway.
// ----------------------------------------------------------------

TestDefault();
// TestUnchecked();
// TestInlineUnchecked();
// TestChecked();
// TestInlineChecked();

public void TestDefault()
{
    int number = int.MaxValue; // 2147483647
    int result = number + 20; // -2147483629

    Console.WriteLine(result);
}

public void TestUnchecked()
{
    unchecked
    {
        int number = int.MaxValue; // 2147483647
        int result = number + 20; // -2147483629

        Console.WriteLine(result);
    }
}

public void TestInlineUnchecked()
{
    int number = int.MaxValue; // 2147483647
    int result = unchecked(number + 20); // -2147483629

    Console.WriteLine(result);
}

public void TestChecked()
{
    checked
    {
        int number = int.MaxValue; // 2147483647
        int result = number + 20; // Throw OverflowException

        Console.WriteLine(result);
    }
}

public void TestInlineChecked()
{
    int number = int.MaxValue; // 2147483647
    int result = checked(number + 20); // Throw OverflowException

    Console.WriteLine(result);
}
