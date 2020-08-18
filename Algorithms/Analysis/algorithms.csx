
public static class Algorithms
{
    // MaxSubArraySum Linear. 4n+2
    public static int MaxSubArraySumLinear(int[] array)
    {
        var maxSum = 0; // 1
        var currentSum = 0; // 1

        for (var i = 0; i < array.Length; i++) // 4n
        {
            currentSum += array[i]; // 1 + 1 = 2

            // if + else if = 2 (Greater value of if-else block)
            if (currentSum < 0) // 1 + 1 = 2
            {
                currentSum = 0; // 1
            }

            else if (currentSum > maxSum) // 1 + 1 = 2
            {
                maxSum = currentSum; // 1
            }
        }

        return maxSum;
    }

    // MaxSubArraySum Cuadratic. 4n2+n+1
    public static int MaxSubArraySumCuadratic(int[] array)
    {
        var maxSum = 0; // 1

        for (var i = 0; i < array.Length; i++) // (4n+1)*n = 4n2+n
        {
            var currentSum = 0; // 1

            for (var j = i; j < array.Length; j++) // 4n
            {
                currentSum += array[j]; // 1 + 1 = 2

                if (currentSum > maxSum) // 1 + 1 = 2
                {
                    maxSum = currentSum; // 1
                }
            }
        }

        return maxSum;
    }

    // MaxSubArraySum Cubic. 2n3+3n2+1
    public static int MaxSubArraySumCubic(int[] array)
    {
        var maxSum = 0; // 1

        for (int i = 0; i < array.Length; i++) // (2n2+3n)*n = 2n3+3n2
        {
            for (var j = 0; j < array.Length; j++) // (2n+3)*n = 2n2+3n
            {
                var currentSum = 0; // 1

                for (var k = i; k <= j; k++) // 2n
                {
                    currentSum += array[k]; // 1 + 1 = 2
                }

                if (currentSum > maxSum) // 1 + 1 = 2
                {
                    maxSum = currentSum; // 1
                }
            }
        }

        return maxSum;
    }
}
