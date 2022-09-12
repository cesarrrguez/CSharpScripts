Func<long, bool> isEven = (number) => number % 2 == 0;

Action<long> collatz = (number) =>
{
    WriteLine(number);
    long result = 0;

    if (isEven(number))
    {
        result = number / 2;
    }
    else
    {
        result = (number * 3) + 1;
    }

    if (result != 1)
    {
        collatz(result);
    }
    else
    {
        WriteLine(result);
    }
};

collatz(13);
