#load "utils.csx"

public static class Algorithms
{
    public static void BubbleSort(int[] array)
    {
        // Steps
        for (var i = 1; i < array.Length; i++)
        {
            // We go through the elements swapping if necessary
            for (var j = 0; j < array.Length - i; j++)
            {
                if (array[j] > array[j + 1])
                    array.Swap(j, j + 1);
            }
        }
    }

    public static void InsertionSort(int[] array)
    {
        int hole;

        for (var i = 1; i < array.Length; i++)
        {
            hole = i;

            // We go through the elements to the hole
            while (hole > 0 && array[hole - 1] > array[i])
            {
                array[hole] = array[hole - 1];
                hole--;
            }

            array[hole] = array[i];
        }
    }

    public static void SelectionSort(int[] array)
    {
        int min;

        for (var i = 0; i < array.Length - 1; i++)
        {
            min = i;

            // Search new minimun index
            for (var j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }

            array.Swap(i, min);
        }
    }

    public static int[] MergeSort(int[] array1, int[] array2)
    {
        var result = new int[array1.Length + array2.Length];
        var i = 0;

        var index1 = 0;
        var index2 = 0;

        // While both arrays have raw elements 
        while (index1 < array1.Length && index2 < array2.Length)
        {
            // If array 1 element is less or equal than array 2 we add array 1 element
            if (array1[index1] <= array2[index2])
            {
                result[i] = array1[index1];
                index1++;
            }
            else // If array 1 element is greater than array 2 we add array 2 element
            {
                result[i] = array2[index2];
                index2++;
            }

            i++;
        }

        // if there were excess elements in array 1 we add them all
        while (index1 < array1.Length)
        {
            result[i] = array1[index1];
            index1++;
            i++;
        }

        // if there were excess elements in array 2 we add them all
        while (index2 < array2.Length)
        {
            result[i] = array2[index2];
            index2++;
            i++;
        }

        return result;
    }

    public static void QuickSort(int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    private static void QuickSort(int[] array, int left, int right)
    {
        if (left >= right) return;

        var pivot = Partition(array, left, right);

        if (pivot > 1)
        {
            QuickSort(array, left, pivot - 1);
        }

        if (pivot + 1 < right)
        {
            QuickSort(array, pivot + 1, right);
        }
    }

    private static int Partition(int[] array, int left, int right)
    {
        var pivot = array[left];

        while (true)
        {
            while (array[left] < pivot)
            {
                left++;
            }

            while (array[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                array.Swap(left, right);
            }
            else
            {
                return right;
            }
        }
    }
}
