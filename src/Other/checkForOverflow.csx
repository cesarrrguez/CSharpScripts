// Checked
// ----------------------------------------------------------------
// Block keyword that enables arithmetic overflow checking. 
// Normally, if an integer operation exceeds the maximum or minimum 
// value that the type can handle, the operation proceeds anyway.
// ----------------------------------------------------------------

int number = int.MaxValue; // 2147483647

TestDefault(number);
// TestUnchecked(number);
// TestInlineUnchecked(number);
// TestChecked(number);
// TestInlineChecked(number);

public void TestDefault(int number)
{
    int result = number + 20; // -2147483629

    Console.WriteLine(result);
}

public void TestUnchecked(int number)
{
    unchecked
    {
        int result = number + 20; // -2147483629

        Console.WriteLine(result);
    }
}

public void TestInlineUnchecked(int number)
{
    int result = unchecked(number + 20); // -2147483629

    Console.WriteLine(result);
}

public void TestChecked(int number)
{
    checked
    {
        int result = number + 20; // Throw OverflowException

        Console.WriteLine(result);
    }
}

public void TestInlineChecked(int number)
{
    int result = checked(number + 20); // Throw OverflowException

    Console.WriteLine(result);
}
