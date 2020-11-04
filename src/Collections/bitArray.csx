using System.Collections;

var array1 = new BitArray(new byte[] { 1, 2, 4, 8, 16 });

// Count. 5 bytes * 8 = 40
Console.WriteLine($"Count: {array1.Count}");
ShowArray(array1, "Array 1");

// Get
Console.WriteLine($"Get: {array1.Get(3)}");

// Set
Console.WriteLine("\nSet:");
array1.Set(3, true);
ShowArray(array1, "Array 1");

// Get
Console.WriteLine($"Get: {array1.Get(3)}");

// Clone
Console.WriteLine("\nClone:");
var array2 = (BitArray)array1.Clone();
ShowArray(array2, "Array 2");

// NOT
Console.WriteLine("\nNOT:");
array2 = array2.Not();
ShowArray(array2, "Array 2");

// OR
Console.WriteLine("\nOR:");
var array3 = new BitArray(new byte[] { 5, 7, 9, 13, 15 });
ShowArray(array1, "Array 1");
ShowArray(array3, "Array 3");
array3.Or(array1);
ShowArray(array3, "1 OR 3 ");

// AND
Console.WriteLine("\nAND:");
ShowArray(array1, "Array 1");
ShowArray(array3, "Array 3");
array3.And(array1);
ShowArray(array3, "1 AND 3");

// XOR
Console.WriteLine("\nXOR:");
ShowArray(array1, "Array 1");
ShowArray(array3, "Array 3");
array3.Xor(array1);
ShowArray(array3, "1 XOR 3");

private void ShowArray(BitArray array, string name)
{
    int c = 0;
    Console.Write($"{name}: ");

    foreach (bool b in array)
    {
        c++;

        if (b)
            Console.Write("1");
        else
            Console.Write("0");

        if (c % 8 == 0)
            Console.Write("  ");
    }

    Console.WriteLine();
}
