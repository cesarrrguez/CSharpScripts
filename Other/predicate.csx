var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Find all evens
var predicate1 = new Predicate<int>(Evens);
var evenNumbers = numbers.FindAll(predicate1);

Console.WriteLine("Find all evens:");
foreach (var item in evenNumbers)
    Console.WriteLine(item);

// Find all in range
var predicate2 = new Predicate<int>(Range);
var rangeNumbers = numbers.FindAll(predicate2);

Console.WriteLine("\nFind all in range 3 - 7:");
foreach (var item in rangeNumbers)
    Console.WriteLine(item);

public static bool Evens(int number)
{
    return number % 2 == 0;
}

public static bool Range(int number)
{
    return number >= 3 && number <= 7;
}
