Console.WriteLine(Factorial(5));
Console.WriteLine(Fibonacci(20));

public static double Factorial(int number)
{
    if (number == 0)
        return 1;
    else
        return number * Factorial(number - 1);
}

public static double Fibonacci(int number)
{
    if (number <= 1)
        return number;
    else
        return Fibonacci(number - 1) + Fibonacci(number - 2);
}
