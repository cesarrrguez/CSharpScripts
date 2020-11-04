public static class Algorithms
{
    // Recursive Binary Search
    public static int BinarySearch(int[] array, int left, int right, int target)
    {
        // Target value not found
        if (right < left) return -1;

        // Get middle value
        var middle = left + ((right - left) / 2);

        // Target value found
        if (array[middle] == target) return middle;

        // Search on left part. Ignore right part
        if (array[middle] > target) right = middle - 1;

        // Search on right part. Ignore left part
        else left = middle + 1;

        // Recursive call
        return BinarySearch(array, left, right, target);
    }

    // Iterative Binary Search
    public static int BinarySearch(int[] array, int target)
    {
        var left = 0;
        var right = array.Length - 1;
        int middle;

        while (left <= right)
        {
            // Get middle value
            middle = left + ((right - left) / 2);

            // Target value found
            if (array[middle] == target) return middle;

            // Search on left part. Ignore right part
            if (array[middle] > target) right = middle - 1;

            // Search on right part. Ignore left part
            else left = middle + 1;
        }

        // Target value not found
        return -1;
    }
}
