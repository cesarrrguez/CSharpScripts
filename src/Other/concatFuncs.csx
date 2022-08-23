Func<int, int, int> fn = (a, b) =>
{
    WriteLine("Sum");
    return a + b;
};

fn += (a, b) =>
{
    WriteLine("Subtract");
    return a - b;
};

fn += (a, b) =>
{
    WriteLine("Multiply");
    return a * b;
};

var result = fn(1, 2);
WriteLine(result);
// Sum
// Subtract
// Multiply
// 2
