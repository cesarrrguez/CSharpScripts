dynamic a = 1;
WriteLine($"{nameof(a)} is type {a.GetType()} and has value {a}");
// a is type System.Int32 and has value 1

a = "duck";
WriteLine($"{nameof(a)} is type {a.GetType()} and has value {a}");
// a is type System.String and has value duck

dynamic number1 = 1, number2 = 3;
Sum(number1, number2);
// Result is (int) 4

number1 = "1";
number2 = "3";
Sum(number1, number2);
// Result is (string) 13

public void Sum(int number1, int number2)
{
    WriteLine($"Result is (int) {number1 + number2}");
}

public void Sum(string number1, string number2)
{
    WriteLine($"Result is (string) {number1 + number2}");
}
