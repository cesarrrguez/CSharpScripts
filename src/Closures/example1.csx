var accumulator1 = Accumulator();
WriteLine(accumulator1());
WriteLine(accumulator1());

var accumulator2 = Accumulator();
WriteLine(accumulator2());

Func<int> Accumulator()
{
    var counter = 0;
    return () =>
    {
        counter++;
        return counter;
    };
}
