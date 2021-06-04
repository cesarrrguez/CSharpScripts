#load "utils.csx"

Func<long, long> factorial;
factorial = n => n > 1 ? n * factorial(n - 1) : 1;

Memoization_No();
Memoization_Yes();

public void Memoization_No()
{
    var stopWatch = Stopwatch.StartNew();

    for (var i = 0; i < 20000000; i++)
    {
        factorial(9);
    }

    stopWatch.Stop();
    WriteLine(stopWatch.ElapsedMilliseconds);
}

public void Memoization_Yes()
{
    var factorial2 = factorial.Memoize();
    var stopWatch2 = Stopwatch.StartNew();

    for (var i = 0; i < 20000000; i++)
    {
        factorial2(9);
    }

    stopWatch2.Stop();
    WriteLine(stopWatch2.ElapsedMilliseconds);
}
