#load "algorithms.csx"

var count = 1000;
var array = new int[count];
Random random = new Random();

for (var i = 0; i < count; i++)
{
    array[i] = random.Next(-100, 100);
}

var stopwatch = new Stopwatch();

// Linear
stopwatch.Start();
var linearResult = Algorithms.MaxSubArraySumLinear(array);
stopwatch.Stop();
Console.WriteLine($"Linear function maximum contiguous sum is: {linearResult}");
Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds\n");

// Cuadratic
stopwatch.Restart();
var cuadraticResult = Algorithms.MaxSubArraySumCuadratic(array);
stopwatch.Stop();
Console.WriteLine($"Cuadratic function maximum contiguous sum is: {cuadraticResult}");
Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds\n");

// Cubic
stopwatch.Restart();
var cubicResult = Algorithms.MaxSubArraySumCubic(array);
stopwatch.Stop();
Console.WriteLine($"Cubic function maximum contiguous sum is: {cubicResult}");
Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds\n");
