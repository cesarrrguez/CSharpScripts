#load "utils.csx"

var array1 = new double[10];
var array2 = new double[10];

array1.Populate(21);
array1.CopyTo(array2);
array1.Clear();

Console.WriteLine("Populate, CopyTo and Clear:");
Console.WriteLine($"Array 1: {string.Join(", ", array1)}");
Console.WriteLine($"Array 2: {string.Join(", ", array2)}");

Console.WriteLine("\nContains:");
Console.WriteLine($"Array 1: {array1.Contains(21)}");
Console.WriteLine($"Array 2: {array2.Contains(21)}");

Console.WriteLine("\nSumSlow:");
Console.WriteLine($"Array 1: {array1.SumSlow()}");
Console.WriteLine($"Array 2: {array2.SumSlow()}");

Console.WriteLine("\nSlice:");
Console.WriteLine($"SubArray 1: {string.Join(", ", array1.Slice(0, 3))}");
