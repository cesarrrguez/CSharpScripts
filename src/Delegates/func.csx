// Func
// -----------------------------------------------------------
// Is a generic delegate type.
// It has zero or more input parameters and one out parameter.
// -----------------------------------------------------------

// Declare function
var function = new Func<int, int, int>(Sum);
var value1 = 5;
var value2 = 9;

// Call function
var result = function(value1, value2);
WriteLine($"{value1} + {value2} = {result}");

public static int Sum(int a, int b)
{
    return a + b;
}
