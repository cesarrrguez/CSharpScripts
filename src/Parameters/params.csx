WriteLine(Add(new int[] { 3, 4, 0 }));
WriteLine(Add(4, 2, 0));
WriteLine(Add(4));
WriteLine(Add());

public int Add(params int[] numbers)
{
    var sum = 0;

    for (var i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }

    return sum;
}
