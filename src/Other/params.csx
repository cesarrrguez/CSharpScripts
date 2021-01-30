Method(1, 1, 'a', "test");

Method();

var array = new object[] { 2, 'b', "test", "again" };
Method(array);

public static void Method(params object[] array)
{
    for (var i = 0; i < array.Length; i++)
    {
        Write(array[i] + " ");
    }
    WriteLine();
}
