var a = 3;
var b = 9;

WriteLine($"{a} * {b} = {Multiply(a, b)}");

public int Multiply(int a, int b)
{
    int result = 0;

    for (var i = 0; i < Math.Abs(b); i++)
    {
        result = b > 0 ? result + a : result - a;
    }

    return result;
}
