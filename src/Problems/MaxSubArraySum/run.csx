int[] array = { -2, -3, 4, -1, -2, 1, 5, -3 };

var result = MaxSubArraySum(array);
WriteLine($"Maximum contiguous sum is: {result}");

public static int MaxSubArraySum(int[] array)
{
    var maxSum = 0;
    var currentSum = 0;

    for (var i = 0; i < array.Length; i++)
    {
        currentSum += array[i];

        if (currentSum < 0)
        {
            currentSum = 0;
        }
        else if (currentSum > maxSum)
        {
            maxSum = currentSum;
        }
    }

    return maxSum;
}
