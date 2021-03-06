#load "algorithms.csx"

using System.Threading;

var stopwatch = new Stopwatch();
var separator = new string(Enumerable.Repeat('-', 30).ToArray());

// Create an array of 6 elements  
var array = new int[] { 1, 43, 5, 202, 101, 10 };

// Do the required sort first
Array.Sort(array);

// Print the values of the array
WriteLine($"Values: {string.Join(", ", array)}");

// Value to search for
var target = 101;

// Result position
var position = 0;

// Recursive implementation
StartImplementation("Recursive implementation:");
position = Algorithms.BinarySearch(array, 0, array.Length - 1, target);
PrintBinarySearchResult(array, position);
FinishImplementation();

// Iterative implementation
StartImplementation("Iterative implementation");
position = Algorithms.BinarySearch(array, target);
PrintBinarySearchResult(array, position);
FinishImplementation();

// .NET framework implementation
StartImplementation("NET framework implementation:");
position = Array.BinarySearch(array, target);
PrintBinarySearchResult(array, position);
FinishImplementation();

public void StartImplementation(string title)
{
    WriteLine($"\n{title}");
    WriteLine(separator);
    stopwatch.Restart();
}

public void FinishImplementation()
{
    stopwatch.Stop();
    WriteLine($"Time elapsed: {stopwatch.Elapsed}");
}

// Print Binary Search result
public void PrintBinarySearchResult(int[] array, int position)
{
    if (position >= 0)
    {
        WriteLine($"Item {array[position]} found at position {position + 1}");
    }
    else
    {
        WriteLine("Item not found");
    }
}
