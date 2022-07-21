var accumulator1 = Accumulator();
WriteLine(accumulator1()); // 1
WriteLine(accumulator1()); // 2

var accumulator2 = Accumulator();
WriteLine(accumulator2()); // 1

Func<int> Accumulator()
{
    var counter = 0;
    return () =>
    {
        counter++;
        return counter;
    };
}
