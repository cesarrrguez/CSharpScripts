#load "algorithms.csx"

var count = 1000;
var array = new int[count];
var random = new Random();

for (var i = 0; i < count; i++)
{
    array[i] = random.Next(-100, 100);
}

var stopwatch = new Stopwatch();

// Linear
stopwatch.Start();
var linearResult = Algorithms.MaxSubArraySumLinear(array);
stopwatch.Stop();
WriteLine($"Linear function maximum contiguous sum is: {linearResult}");
WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

// Cuadratic
stopwatch.Restart();
var cuadraticResult = Algorithms.MaxSubArraySumCuadratic(array);
stopwatch.Stop();
WriteLine($"\nCuadratic function maximum contiguous sum is: {cuadraticResult}");
WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

// Cubic
stopwatch.Restart();
var cubicResult = Algorithms.MaxSubArraySumCubic(array);
stopwatch.Stop();
WriteLine($"\nCubic function maximum contiguous sum is: {cubicResult}");
WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
