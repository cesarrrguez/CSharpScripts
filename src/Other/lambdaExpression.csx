var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Find all
var evenNumbers = numbers.FindAll(x => x % 2 == 0);

WriteLine($"Even list: {string.Join(", ", evenNumbers)}");

WriteLine();

// Find all 2
evenNumbers = numbers.FindAll(x =>
{
    if (x % 2 == 0)
    {
        WriteLine("Even");
        return true;
    }
    else
    {
        WriteLine("Odd");
        return false;
    }
});

WriteLine($"\nEven list: {string.Join(", ", evenNumbers)}");
