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
WriteLine($"Linear function maximum contiguous sum is: {linearResult}");
WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds\n");

// Cuadratic
stopwatch.Restart();
var cuadraticResult = Algorithms.MaxSubArraySumCuadratic(array);
stopwatch.Stop();
WriteLine($"Cuadratic function maximum contiguous sum is: {cuadraticResult}");
WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds\n");

// Cubic
stopwatch.Restart();
var cubicResult = Algorithms.MaxSubArraySumCubic(array);
stopwatch.Stop();
WriteLine($"Cubic function maximum contiguous sum is: {cubicResult}");
WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds\n");
