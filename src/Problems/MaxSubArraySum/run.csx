var array = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };

var result = MaxSubArraySum(array);
WriteLine($"Maximum contiguous sum is: {result}"); // 7

result = MaxSubArraySum2(array);
WriteLine($"Maximum contiguous sum is: {result}"); // 7

public int MaxSubArraySum(int[] array)
{
    var sum = array[0];
    var result = array[0];

    for (var i = 1; i < array.Length; i++)
    {
        sum += array[i];

        if (sum < 0)
        {
            sum = 0;
        }
        else if (sum > result)
        {
            result = sum;
        }
    }

    return result;
}

public int MaxSubArraySum2(int[] array)
{
    var sum = array[0];
    var result = array[0];

    for (var i = 1; i < array.Length; i++)
    {
        sum = Math.Max(sum + array[i], array[i]);
        result = Math.Max(result, sum);
    }

    return result;
}
