#load "utils.csx"

Func<long, long> factorial;
factorial = n => n > 1 ? n * factorial(n - 1) : 1;

Memoization_No();
Memoization_Yes();

public void Memoization_No()
{
    var stopwatch = Stopwatch.StartNew();

    for (var i = 0; i < 20000000; i++)
    {
        factorial(9);
    }

    stopwatch.Stop();
    WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
}

public void Memoization_Yes()
{
    var factorial2 = factorial.Memoize();
    var stopwatch = Stopwatch.StartNew();

    for (var i = 0; i < 20000000; i++)
    {
        factorial2(9);
    }

    stopwatch.Stop();
    WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
}
