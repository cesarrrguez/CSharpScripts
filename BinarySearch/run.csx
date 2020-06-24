// Binary Search
// ---------------------------------------------------------------------------------
// Search algorithm that finds the position of a target value within a sorted array.
// Binary search compares the target value to the middle element of the array. 
// If they are not equal, the half in which the target cannot lie is eliminated and 
// the search continues on the remaining half, again taking the middle element to 
// compare to the target value, and repeating this until the target value is found.
// If the search ends with the remaining half being empty, the target is not in the array.
// ---------------------------------------------------------------------------------

#load "utils.csx"

using System.Threading;

var stopwatch = new Stopwatch();
var separator = new string(Enumerable.Repeat('-', 30).ToArray());

// Create an array of 6 elements  
var array = new int[] { 1, 43, 5, 202, 101, 10 };

// Do the required sort first
Array.Sort(array);

// Print the values of the array
Console.WriteLine($"Values: {String.Join(", ", array)}");

// Value to search for
var target = 101;

// Result position
int position = 0;

// Recursive implementation
StartImplementation("Recursive implementation:");
position = BinarySearch(array, 0, array.Length - 1, target);
PrintBinarySearchResult(array, position);
FinishImplementation();

// Iterative implementation
StartImplementation("Iterative implementation");
position = BinarySearch(array, target);
PrintBinarySearchResult(array, position);
FinishImplementation();

// .NET framework implementation
StartImplementation("NET framework implementation:");
position = Array.BinarySearch(array, target);
PrintBinarySearchResult(array, position);
FinishImplementation();

void StartImplementation(string title)
{
    Console.WriteLine($"\n{title}");
    Console.WriteLine(separator);
    stopwatch.Restart();
}

void FinishImplementation()
{
    stopwatch.Stop();
    Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
}
