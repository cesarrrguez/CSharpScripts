var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Find all evens
var predicate1 = new Predicate<int>(Evens);
var evenNumbers = numbers.FindAll(predicate1);
WriteLine($"Find all evens: {string.Join(", ", evenNumbers)}");
WriteLine($"Exists evens: {numbers.Exists(predicate1)}");

// Find all in range
var predicate2 = new Predicate<int>(Range);
var rangeNumbers = numbers.FindAll(predicate2);
WriteLine($"\nFind all in range [3 - 7]: {string.Join(", ", rangeNumbers)}");

public static bool Evens(int number) => number % 2 == 0;

public static bool Range(int number) => number >= 3 && number <= 7;
