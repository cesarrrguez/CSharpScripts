// Multiply
// ------------------------------------------------------------------------
// Multiply two numbers without using multiplication operator.
// Given two integers, multiply them without using multiplication operator.
// ------------------------------------------------------------------------

var a = 3;
var b = 9;

WriteLine($"{a} * {b} = {Multiply(a, b)}");

public static int Multiply(int a, int b)
{
    int result = 0;

    for (int i = 0; i < Math.Abs(b); i++)
    {
        result = b > 0 ? result + a : result - a;
    }

    return result;
}
