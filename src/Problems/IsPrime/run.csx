var numbers = new List<int>();

for (int i = 0; i <= 100; i++)
{
    if (IsPrime(i))
    {
        numbers.Add(i);
    }
}

WriteLine($"{string.Join(", ", numbers)}");

public bool IsPrime(int number)
{
    if (number <= 1) return false;

    for (int i = 2; i < number; i++)
    {
        if (number % i == 0) return false;
    }

    return true;
}
