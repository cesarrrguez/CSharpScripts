dynamic a = 1;
Console.WriteLine($"{nameof(a)} is type {a.GetType()} and has value {a}");

a = "duck";
Console.WriteLine($"{nameof(a)} is type {a.GetType()} and has value {a}");

dynamic number1 = 1, number2 = 3;
Sum(number1, number2);

number1 = "1";
number2 = "3";
Sum(number1, number2);

public static void Sum(int number1, int number2)
{
    Console.WriteLine($"Result is (int) {number1 + number2}");
}

public static void Sum(string number1, string number2)
{
    Console.WriteLine($"Result is (string) {number1 + number2}");
}
