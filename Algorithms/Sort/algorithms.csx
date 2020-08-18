#load "utils.csx"

public static class Algorithms
{
    // Bubble sort
    // ------------------------------------------------------------------------
    // Repeatedly steps through the array, compares adjacent elements and swaps 
    // them if they are in the wrong order. 
    // The pass through the array is repeated until the array is sorted.
    // ------------------------------------------------------------------------
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

    // Insertion sort
    // ------------------------------------------------------------------------
    // Builds the final sorted array one item at a time.
    // ------------------------------------------------------------------------
    public static void InsertionSort(int[] array)
    {
        var hole = 0;

        for (var i = 1; i < array.Length; i++)
        {
            hole = i;

            // we go through the elements to the hole
            while (hole > 0 && array[hole - 1] > array[i])
            {
                array[hole] = array[hole - 1];
                hole -= 1;
            }

            array[hole] = array[i];
        }
    }

    // Selection sort
    // ------------------------------------------------------------------------
    // The algorithm proceeds by finding the smallest element in the unsorted 
    // array, swapping it with the left most unsorted element, and moving the 
    // sublist boundaries one element to the right.
    // ------------------------------------------------------------------------
    public static void SelectionSort(int[] array)
    {
        var min = 0;

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

    // Merge sort
    // ------------------------------------------------------------------------
    // 1. Divide the unsorted list into n sublists, each containing one element 
    // (a list of one element is considered sorted).
    // ------------------------------------------------------------------------
    // 2. Repeatedly merge sublists to produce new sorted sublists until there 
    // is only one sublist remaining. This will be the sorted list.
    // ------------------------------------------------------------------------
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

    // Quick sort
    // ------------------------------------------------------------------------
    // It works by selecting a 'pivot' element from the array and partitioning 
    // the other elements into two sub-arrays, according to whether they are less
    // than or greater than the pivot. The sub-arrays are then sorted recursively.
    // ------------------------------------------------------------------------
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
