var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Find all
var evenNumbers = numbers.FindAll(x => x % 2 == 0);

Console.WriteLine($"Even list: {string.Join(", ", evenNumbers)}");

Console.WriteLine();

// Find all 2
evenNumbers = numbers.FindAll(x =>
{
    if (x % 2 == 0)
    {
        Console.WriteLine("Even");
        return true;
    }
    else
    {
        Console.WriteLine("Odd");
        return false;
    }
});

Console.WriteLine($"\nEven list: {string.Join(", ", evenNumbers)}");
