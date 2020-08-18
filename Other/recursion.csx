// Factorial 5. 5! = 5*4*3*2*1
Console.WriteLine($"Factorial 5: {Factorial(5)}");

// Fibonacci 7. F(0)=0, F(1)=1, F(2)=1, F(3)=2, F(4)=3, F(5)=5, F(6)=8, F(7)=13
Console.WriteLine($"Fibonacci 7: {Fibonacci(7)}");

public static double Factorial(int number)
{
    if (number == 1) return 1;  // Base case
    return number * Factorial(number - 1); // Inductive case
}

public static double Fibonacci(int number)
{
    if (number <= 1) return number; // Base case
    return Fibonacci(number - 1) + Fibonacci(number - 2); // Inductive case
}
