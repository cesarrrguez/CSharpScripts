#load "algorithms.csx"
#load "utils.csx"

var unsortedArray = new int[] { 1, 43, 5, 202, 101, 10 };
var array = new int[unsortedArray.Length];

// Unsorted array
unsortedArray.CopyTo(array);
Console.WriteLine($"Unsorted array: {string.Join(", ", array.ToList())}\n");

// Bubble sort
unsortedArray.CopyTo(array);
Algorithms.BubbleSort(array);
Console.WriteLine($"Bubble sort: {string.Join(", ", array.ToList())}");

// Insertion sort
unsortedArray.CopyTo(array);
Algorithms.InsertionSort(array);
Console.WriteLine($"Insertion sort: {string.Join(", ", array.ToList())}");

// Selection sort
unsortedArray.CopyTo(array);
Algorithms.SelectionSort(array);
Console.WriteLine($"Selection sort: {string.Join(", ", array.ToList())}");

// Merge sort
var array1 = new int[] { 1, 5, 101 };
var array2 = new int[] { 10, 43, 202 };
array = Algorithms.MergeSort(array1, array2);
Console.WriteLine($"Merge sort: {string.Join(", ", array.ToList())}");

// Quick sort
unsortedArray.CopyTo(array);
Algorithms.QuickSort(array);
Console.WriteLine($"Quick sort: {string.Join(", ", array.ToList())}");
